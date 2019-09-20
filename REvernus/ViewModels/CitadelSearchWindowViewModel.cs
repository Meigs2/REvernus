using EVEStandard.Models;
using EVEStandard.Models.API;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using REvernus.Core.ESI;
using Universe = EVEStandard.API.Universe;

namespace REvernus.ViewModels
{
    public class CitadelSearchWindowViewModel : BindableBase
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ObservableCollection<Structure> _citadelListItems = new ObservableCollection<Structure>();
        private string _searchBoxText;
        private bool _includePublicCitadels;

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

        public bool IncludePublicCitadels
        {
            get => _includePublicCitadels;
            set => SetProperty(ref _includePublicCitadels, value);
        }

        public CitadelSearchWindowViewModel()
        {
            SearchCommand = new DelegateCommand(async () => await SearchEsiForCitadels());
            SelectCommand = new DelegateCommand<IList>(SelectCitadels);
        }

        public List<Structure> SelectedStructures { get; set; } = new List<Structure>();

        private void SelectCitadels(IList selectedStructures)
        {
            SelectedStructures.Clear();

            foreach (var structure in selectedStructures)
            {
                SelectedStructures.Add(structure as Structure);
            }
        }

        public DelegateCommand SearchCommand { get; set; }

        public DelegateCommand<IList> SelectCommand { get; set; }

        private async Task SearchEsiForCitadels()
        {
            var auth = new AuthDTO()
            {
                AccessToken = Core.CharacterManager.SelectedCharacter.AccessTokenDetails,
                CharacterId = Core.CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                Scopes = EVEStandard.Enumerations.Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1 + EVEStandard.Enumerations.Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1 + EVEStandard.Enumerations.Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
            };

            CitadelListItems.Clear();

            var taskList = new List<Task>();
            var citadelList = new ConcurrentBag<Structure>(); 

            var citadelSearchResult = await Core.ESI.EsiData.EsiClient.Search.SearchCharacterV3Async(auth, new List<string>() { EVEStandard.Enumerations.SearchCategory.STRUCTURE }, SearchBoxText);

            if (citadelSearchResult.Model.Structure != null)
            {
                foreach (var structure in citadelSearchResult.Model.Structure)
                {
                    try
                    {
                        taskList.Add(Task.Run(async () =>
                        {
                            var statusHandle = new Utilities.StatusHandle();
                            try
                            {
                                var structureInfo =
                                    await Core.ESI.EsiData.EsiClient.Universe.GetStructureInfoV2Async(auth, structure);
                                citadelList.Add(structureInfo.Model);
                            }
                            finally
                            {
                                statusHandle.Dispose();
                            }
                        }));
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }

            if (IncludePublicCitadels)
            {
                var allPublicStructures = await Core.ESI.EsiData.EsiClient.Universe.ListAllPublicStructuresV1Async(Universe.StructureHas.NoFilter);
                foreach (var structureId in allPublicStructures.Model)
                {
                    taskList.Add(Task.Run(async () =>
                    {
                        try
                        {
                            var structureInfo =
                                await EsiData.EsiClient.Universe.GetStructureInfoV2Async(auth, structureId);
                            if (structureInfo.Model.Name.Contains(SearchBoxText))
                            {
                                CitadelListItems.Add(structureInfo.Model);
                            }
                        }
                        catch (Exception)
                        {
                            // Ignored
                        }
                    }));
                }
            }

            await Task.WhenAll(taskList);

            CitadelListItems = new ObservableCollection<Structure>(citadelList);
        }
    }
}