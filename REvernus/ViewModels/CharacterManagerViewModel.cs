namespace REvernus.ViewModels
{
    using System;
    using System.Net;
    using System.Reflection;

    using JetBrains.Annotations;

    using log4net;

    using Prism.Commands;

    using REvernus.Models;

    public class CharacterManagerViewModel
    {
        // ReSharper disable once PossibleNullReferenceException
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
                App.CharacterManager.AuthorizeNewCharacter();
            }
            catch (Exception e)
            {
                if (!(e is HttpListenerException))
                    Log.Error(e);
            }
        }

        private void RemoveCharacters()
        {
        }

        #region Commands

        public DelegateCommand AddCharacterCommand { get; set; }

        [UsedImplicitly]
        public DelegateCommand RemoveCharacterCommand { get; set; }

        #endregion
    }
}