using System;
using System.Net;
using Prism.Commands;
using REvernus.Models;

namespace REvernus.ViewModels
{
    public class CharacterManagerViewModel
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
            try
            {
                App.CharacterManager.AuthorizeNewCharacter();
            }
            catch (Exception e)
            {
                if (!(e is HttpListenerException))
                {
                    Log.Error(e);
                }
            }
        }

        private void RemoveCharacters()
        {

        }
    }
}
