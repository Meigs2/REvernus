using EVEStandard.Models;
using EVEStandard.Models.API;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Universe = EVEStandard.API.Universe;

namespace REvernus.ViewModels
{
    public class CitadelSearchWindowViewModel : BindableBase
    {
        private ObservableCollection<Structure> _citadelListItems = new ObservableCollection<Structure>();
        private string _searchBoxText;
        private bool _excludePublicCitadels;

        public ObservableCollection<Structure> CitadelListItems
        {
            get => _citadelListItems;
            set => SetProperty(ref _citadelListItems, value);
        }

        public string SearchBoxText
        {
            get => _searchBoxText;
            set => SetProperty(ref _searchBoxText, value);
        }

        public bool ExcludePublicCitadels
        {
            get => _excludePublicCitadels;
            set => SetProperty(ref _excludePublicCitadels, value);
        }

        public CitadelSearchWindowViewModel()
        {
            SearchCommand = new DelegateCommand(async () => await SearchEsiForCitadels());
        }

        public DelegateCommand SearchCommand { get; set; }

        private async Task SearchEsiForCitadels()
        {
            var auth = new AuthDTO()
            {
                AccessToken = Core.CharacterManager.SelectedCharacter.AccessTokenDetails,
                CharacterId = Core.CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                Scopes = EVEStandard.Enumerations.Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1 + EVEStandard.Enumerations.Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1 + EVEStandard.Enumerations.Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
            };

            CitadelListItems.Clear();

            var characterSearchResult = await Core.ESI.EsiData.EsiClient.Search.SearchCharacterV3Async(auth, new List<string>() { EVEStandard.Enumerations.SearchCategory.STRUCTURE }, SearchBoxText);

            if (characterSearchResult.Model.Structure != null)
            {
                foreach (var structure in characterSearchResult.Model.Structure)
                {
                    try
                    {
                        var structureInfo =
                            await Core.ESI.EsiData.EsiClient.Universe.GetStructureInfoV2Async(auth, structure);
                        CitadelListItems.Add(structureInfo.Model);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }

            if (!ExcludePublicCitadels)
            {
                var allPublicStructures = await Core.ESI.EsiData.EsiClient.Universe.ListAllPublicStructuresV1Async(Universe.StructureHas.NoFilter);
                foreach (var structure in allPublicStructures.Model)
                {
                    var structureInfo =
                        await Core.ESI.EsiData.EsiClient.Universe.GetStructureInfoV2Async(auth, structure);
                    if (structureInfo.Model.Name.Contains(SearchBoxText))
                    {
                        CitadelListItems.Add(structureInfo.Model);
                    }
                }
            }
        }
    }
}