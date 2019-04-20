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

        #endregion

        public CharacterManagerViewModel()
        {
            AddCharacterCommand = new DelegateCommand(AddNewCharacter);
            CharacterManager.CurrentInstance.NewCharacterAdded += RefreshModelCharacterList;
        }

        private void RefreshModelCharacterList(object sender, EventArgs e)
        {
            Model.Characters = CharacterManager.CurrentInstance.CharacterList.ToList();
        }

        private void AddNewCharacter()
        {
            CharacterManager.AuthorizeNewCharacter();
        }
    }
}
