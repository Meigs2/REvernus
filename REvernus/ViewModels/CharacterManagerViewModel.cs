using System;
using System.Linq;
using Prism.Commands;
using REvernus.Core;
using REvernus.Models;

namespace REvernus.ViewModels
{
    public class CharacterManagerViewModel
    {
        public CharacterManagerModel Model { get; set; } = new CharacterManagerModel();

        #region Commands

        public DelegateCommand AddCharacterCommand { get; set; }

        public DelegateCommand RemoveCharacterCommand { get; set; }

        #endregion

        public CharacterManagerViewModel()
        {
            AddCharacterCommand = new DelegateCommand(AddNewCharacter);

            RemoveCharacterCommand = new DelegateCommand(RemoveCharacters);
        }

        private void AddNewCharacter()
        {
            CharacterManager.AuthorizeNewCharacter();
        }

        private void RemoveCharacters()
        {

        }
    }
}
