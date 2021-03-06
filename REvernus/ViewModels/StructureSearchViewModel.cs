﻿using EVEStandard.Models;
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
    public class StructureSearchViewModel : BindableBase
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private ObservableCollection<PlayerStructure> _structureListItems = new ObservableCollection<PlayerStructure>();
        private string _searchBoxText;
        private bool _includePublicStructures;
        private bool _isEnabled = true;
        private REvernusCharacter _selectedCharacter;

        public ObservableCollection<REvernusCharacter> Characters { get; set; }

        public REvernusCharacter SelectedCharacter
        {
            get => _selectedCharacter;
            set
            {
                _selectedCharacter = value;
                StructureListItems.Clear();
            }
        }

        public ObservableCollection<PlayerStructure> StructureListItems
        {
            get => _structureListItems;
            set => SetProperty(ref _structureListItems, value);
        }

        public string SearchBoxText
        {
            get => _searchBoxText;
            set => SetProperty(ref _searchBoxText, value);
        }

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

        public StructureSearchViewModel()
        {
            SearchCommand = new DelegateCommand(async () => await SearchEsiForStructures());
            SelectCommand = new DelegateCommand<IList>(SelectStructures);

            Characters = new ObservableCollection<REvernusCharacter>(CharacterManager.CharacterList);
            SelectedCharacter = CharacterManager.SelectedCharacter;
        }

        public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();

        private void SelectStructures(IList selectedStructures)
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

        private async Task SearchEsiForStructures()
        {
            IsEnabled = false;

            try
            {
                var auth = new AuthDTO()
                {
                    AccessToken = SelectedCharacter.AccessTokenDetails,
                    CharacterId = SelectedCharacter.CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1 + Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1 + Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
                };

                StructureListItems.Clear();

                var taskList = new List<Task>();
                var structureList = new ConcurrentBag<PlayerStructure>(); 

                var structureSearchResult = await EsiData.EsiClient.Search.SearchCharacterV3Async(auth, new List<string>() { SearchCategory.STRUCTURE }, SearchBoxText);

                if (structureSearchResult.Model.Structure != null)
                {
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
                                        StructureToPlayerStructure(structureId, structure, SelectedCharacter);
                                    structureList.Add(playerStructure);
                                }
                            }));
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }

                if (IncludePublicStructures)
                {
                    var allPublicStructures = await EsiData.EsiClient.Universe.ListAllPublicStructuresV1Async(Universe.StructureHas.NoFilter);
                    foreach (var structureId in allPublicStructures.Model)
                    {
                        taskList.Add(Task.Run(async () =>
                        {
                            var structure = await Structures.GetStructureInfoAsync(auth, structureId, SearchBoxText);
                            if (structure != null)
                            {
                                var playerStructure = StructureToPlayerStructure(structureId, structure, SelectedCharacter);
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

        private static PlayerStructure StructureToPlayerStructure(long structureId, Structure structure, REvernusCharacter selectedCharacter)
        {
            return new PlayerStructure()
            {
                StructureId = structureId,
                OwnerId = structure.OwnerId,
                Name = structure.Name,
                SolarSystemId = structure.SolarSystemId,
                TypeId = structure.TypeId,
                AddedBy = selectedCharacter.CharacterDetails.CharacterId,
                AddedAt = null,
                Enabled = null
            };
        }

        public event EventHandler<StructureSearchEventArgs> SelectPressed;

        protected virtual void OnSelectPressed()
        {
            SelectPressed?.Invoke(this, new StructureSearchEventArgs(){ SelectedStructures = SelectedStructures });
        }

        public class StructureSearchEventArgs : EventArgs
        {
            public List<PlayerStructure> SelectedStructures { get; set; } = new List<PlayerStructure>();
        }
    }
}