using log4net;
using Prism.Commands;
using REvernus.Models;
using System;
using System.Net;
using System.Reflection;

namespace REvernus.ViewModels
{
    public class CharacterManagerViewModel
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public CharacterManagerViewModel()
        {
            AddCharacterCommand = new DelegateCommand(AddNewCharacter);

            RemoveCharacterCommand = new DelegateCommand(RemoveCharacters);
        }

        public CharacterManagerModel Model { get; set; } = new CharacterManagerModel();

        private void AddNewCharacter()
        {
            try
            {
                App.AuthProvider.AuthorizeNewCharacter();
            }
            catch (Exception e)
            {
                if (!(e is HttpListenerException)) Log.Error(e);
            }
        }

        private void RemoveCharacters()
        {
        }

        #region Commands

        public DelegateCommand AddCharacterCommand { get; set; }

        public DelegateCommand RemoveCharacterCommand { get; set; }

        #endregion
    }
}