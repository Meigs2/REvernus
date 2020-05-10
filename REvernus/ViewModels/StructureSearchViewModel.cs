namespace REvernus.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Threading.Tasks;

    using EVEStandard.Enumerations;
    using EVEStandard.Models;
    using EVEStandard.Models.API;

    using log4net;

    using Prism.Commands;
    using Prism.Mvvm;

    using REvernus.Core.ESI;
    using REvernus.Models;

    using Universe = EVEStandard.API.Universe;

    public class StructureSearchViewModel : BindableBase
    {
        // ReSharper disable once UnusedMember.Local
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private bool _includePublicStructures;
        private bool _isEnabled = true;
        private string _searchBoxText;
        private REvernusCharacter _selectedCharacter;

        private ObservableCollection<PlayerStructure> _structureListItems = new ObservableCollection<PlayerStructure>();

        public StructureSearchViewModel()
        {
            SearchCommand = new DelegateCommand(async () => await SearchEsiForStructures());
            SelectCommand = new DelegateCommand<IList>(SelectStructures);

            Characters = new ObservableCollection<REvernusCharacter>(App.CharacterManager.CharacterList);
            SelectedCharacter = App.CharacterManager.SelectedCharacter;
        }

        public ObservableCollection<REvernusCharacter> Characters { get; set; }

        public bool IncludePublicStructures
        {
            get => _includePublicStructures;
            set => SetProperty(ref _includePublicStructures, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        public string SearchBoxText
        {
            get => _searchBoxText;
            set => SetProperty(ref _searchBoxText, value);
        }

        public DelegateCommand SearchCommand { get; set; }

        public DelegateCommand<IList> SelectCommand { get; set; }

        public REvernusCharacter SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                _selectedCharacter = value;
                StructureListItems.Clear();
            }
        }

        public List<PlayerStructure> SelectedStructures { get; } = new List<PlayerStructure>();

        public ObservableCollection<PlayerStructure> StructureListItems
        {
            get => _structureListItems;
            set => SetProperty(ref _structureListItems, value);
        }

        public object IsSelected
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<StructureSearchEventArgs> SelectPressed;

        protected virtual void OnSelectPressed()
        {
            SelectPressed?.Invoke(this, new StructureSearchEventArgs { SelectedStructures = SelectedStructures });
        }

        private async Task SearchEsiForStructures()
        {
            IsEnabled = false;

            try
            {
                var auth = new AuthDTO
                {
                    AccessToken = SelectedCharacter.AccessTokenDetails,
                    CharacterId = SelectedCharacter.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1 + Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1 +
                             Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
                };

                StructureListItems.Clear();

                var taskList = new List<Task>();
                var structureList = new ConcurrentBag<PlayerStructure>();

                var structureSearchResult = await EsiData.EsiClient.Search.SearchCharacterV3Async(auth,
                    new List<string> { SearchCategory.STRUCTURE }, SearchBoxText);

                if (structureSearchResult.Model.Structure != null)
                    foreach (var structureId in structureSearchResult.Model.Structure)
                    {
                        try
                        {
                            taskList.Add(Task.Run(async () =>
                            {
                                var structure = await Structures.GetStructureInfoAsync(auth, structureId);
                                if (structure != null)
                                {
                                    var playerStructure =
                                        StructureToPlayerStructure(structureId, structure, SelectedCharacter, false);
                                    structureList.Add(playerStructure);
                                }
                            }));
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                if (IncludePublicStructures)
                {
                    var allPublicStructures =
                        await EsiData.EsiClient.Universe.ListAllPublicStructuresV1Async(Universe.StructureHas.NoFilter);
                    foreach (var structureId in allPublicStructures.Model)
                    {
                        taskList.Add(Task.Run(async () =>
                        {
                            var structure = await Structures.GetStructureInfoAsync(auth, structureId, SearchBoxText);
                            if (structure != null)
                            {
                                var playerStructure =
                                    StructureToPlayerStructure(structureId, structure, SelectedCharacter, true);
                                structureList.Add(playerStructure);
                            }
                        }));
                    }
                }

                await Task.WhenAll(taskList);

                StructureListItems = new ObservableCollection<PlayerStructure>(structureList);
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void SelectStructures(IList selectedStructures)
        {
            SelectedStructures.Clear();

            foreach (var structure in selectedStructures)
            {
                SelectedStructures.Add(structure as PlayerStructure);
            }

            OnSelectPressed();
        }

        private static PlayerStructure StructureToPlayerStructure(long structureId, Structure structure,
            REvernusCharacter selectedCharacter, bool isPublic)
        {
            return new PlayerStructure
            {
                StructureId = structureId,
                OwnerId = structure.OwnerId,
                Name = structure.Name,
                SolarSystemId = structure.SolarSystemId,
                TypeId = structure.TypeId,
                AddedBy = selectedCharacter.CharacterDetails.CharacterId,
                AddedAt = null,
                Enabled = null,
                IsPublic = isPublic
            };
        }

        public class StructureSearchEventArgs : EventArgs
        {
            public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();
        }
    }
}