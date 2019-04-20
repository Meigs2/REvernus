using Prism.Mvvm;
using REvernus.Core.CharacterManagement;
using REvernus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace REvernus.Core
{
    public class CharacterManager : BindableBase
    {

        #region Variables and Properties

        private static CharacterManager _currentInstance;
        public static CharacterManager CurrentInstance => _currentInstance ?? (_currentInstance = new CharacterManager());

        internal HashSet<REvernusCharacter> CharacterList { get; set; } = new HashSet<REvernusCharacter>();

        private REvernusCharacter _selectedCharacter;
        public REvernusCharacter SelectedCharacter
        {
            get => _selectedCharacter ?? (_selectedCharacter = new REvernusCharacter());
            set => SetProperty(ref _selectedCharacter, value);
        }

        #endregion

        #region Public Methods

        public static void AuthorizeNewCharacter()
        {
            var verificationWindow = new VerificationWindow(ESI.EsiData.EsiClient);
            verificationWindow.ShowDialog();

            var duplicateCharacter =
                CharacterManager.CurrentInstance.CharacterList.SingleOrDefault(
                    c => c.CharacterDetails.CharacterName == verificationWindow.Character.CharacterDetails.CharacterName);
            if (duplicateCharacter != null)
            {
                var dialogResult = MessageBox.Show($"{duplicateCharacter.CharacterDetails.CharacterName} is already added!", "", MessageBoxButton.OK);
                return;
            }

            CharacterManager.CurrentInstance.CharacterList.Add(verificationWindow.Character);
            CharacterManager.CurrentInstance.OnNewCharacterAdded();
        }

        #endregion

        #region Private Methods



        #endregion

        #region MyRegion

        public event EventHandler SelectedCharacterChanged;
        protected virtual void OnSelectedCharacterChanged()
        {
            SelectedCharacterChanged?.Invoke(this, EventArgs.Empty);
        }


        public event EventHandler NewCharacterAdded;
        protected virtual void OnNewCharacterAdded()
        {
            NewCharacterAdded?.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}
