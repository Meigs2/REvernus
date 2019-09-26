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
using EVEStandard.Enumerations;
using REvernus.Core;
using REvernus.Core.ESI;
using REvernus.Models;
using Universe = EVEStandard.API.Universe;

namespace REvernus.ViewModels
{
    public class CitadelSearchWindowViewModel : BindableBase
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ObservableCollection<PlayerStructure> _citadelListItems = new ObservableCollection<PlayerStructure>();
        private string _searchBoxText;
        private bool _includePublicCitadels;
        private bool _isEnabled = true;

        public ObservableCollection<PlayerStructure> CitadelListItems
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

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public CitadelSearchWindowViewModel()
        {
            SearchCommand = new DelegateCommand(async () => await SearchEsiForCitadels());
            SelectCommand = new DelegateCommand<IList>(SelectCitadels);
        }

        public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();

        private void SelectCitadels(IList selectedStructures)
        {
            SelectedStructures.Clear();

            foreach (var structure in selectedStructures)
            {
                SelectedStructures.Add(structure as PlayerStructure);
            }

            OnSelectPressed();
        }

        public DelegateCommand SearchCommand { get; set; }

        public DelegateCommand<IList> SelectCommand { get; set; }

        private async Task SearchEsiForCitadels()
        {
            IsEnabled = false;

            try
            {
                var auth = new AuthDTO()
                {
                    AccessToken = CharacterManager.SelectedCharacter.AccessTokenDetails,
                    CharacterId = CharacterManager.SelectedCharacter.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1 + Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1 + Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
                };

                CitadelListItems.Clear();

                var taskList = new List<Task>();
                var citadelList = new ConcurrentBag<PlayerStructure>(); 

                var citadelSearchResult = await EsiData.EsiClient.Search.SearchCharacterV3Async(auth, new List<string>() { SearchCategory.STRUCTURE }, SearchBoxText);

                if (citadelSearchResult.Model.Structure != null)
                {
                    foreach (var structureId in citadelSearchResult.Model.Structure)
                    {
                        try
                        {
                            taskList.Add(Task.Run(async () =>
                            {
                                var structure = await Citadels.GetStructureInfoAsync(auth, structureId);
                                if (structure != null)
                                {
                                    var playerStructure = new PlayerStructure()
                                    {
                                        StructureId = structureId, 
                                        OwnerId = structure.OwnerId,
                                        Name = structure.Name, 
                                        Position = structure.Position, 
                                        SolarSystemId = structure.SolarSystemId, 
                                        TypeId = structure.TypeId
                                    };
                                    citadelList.Add(playerStructure);
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
                    var allPublicStructures = await EsiData.EsiClient.Universe.ListAllPublicStructuresV1Async(Universe.StructureHas.NoFilter);
                    foreach (var structureId in allPublicStructures.Model)
                    {
                        taskList.Add(Task.Run(async () =>
                        {
                            var structure = await Citadels.GetStructureInfoAsync(auth, structureId, SearchBoxText);
                            if (structure != null)
                            {
                                var playerStructure = new PlayerStructure()
                                {
                                    StructureId = structureId,
                                    OwnerId = structure.OwnerId,
                                    Name = structure.Name,
                                    Position = structure.Position,
                                    SolarSystemId = structure.SolarSystemId,
                                    TypeId = structure.TypeId
                                };
                                citadelList.Add(playerStructure);
                            }
                        }));
                    }
                }

                await Task.WhenAll(taskList);

                CitadelListItems = new ObservableCollection<PlayerStructure>(citadelList);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        public event EventHandler<CitadelSearchEventArgs> SelectPressed;

        protected virtual void OnSelectPressed()
        {
            SelectPressed?.Invoke(this, new CitadelSearchEventArgs(){ SelectedStructures = SelectedStructures });
        }

        public class CitadelSearchEventArgs : EventArgs
        {
            public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();
        }
    }
}