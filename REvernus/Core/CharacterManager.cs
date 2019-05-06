using Prism.Mvvm;
using REvernus.Core.CharacterManagement;
using REvernus.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace REvernus.Core
{
    public class CharacterManager : BindableBase
    {
        private static CharacterManager _currentInstance;
        public static CharacterManager CurrentInstance => _currentInstance ??= new CharacterManager();

        private ObservableCollection<REvernusCharacter> _characterList;

        public static ObservableCollection<REvernusCharacter> CharacterList
        {
            get => CurrentInstance._characterList ??= new ObservableCollection<REvernusCharacter>();
            set
            {
                if (value != CurrentInstance._characterList)
                {
                    CurrentInstance.SetProperty(ref CurrentInstance._characterList, value);
                    CurrentInstance.OnCharactersChanged();
                }
            }
        }

        private REvernusCharacter _selectedCharacter;
        public static REvernusCharacter SelectedCharacter
        {
            get => CurrentInstance._selectedCharacter ??= new REvernusCharacter();
            set
            {
                if (value != CurrentInstance._selectedCharacter)
                {
                    CurrentInstance.SetProperty(ref CurrentInstance._selectedCharacter, value);
                    CurrentInstance.OnSelectedCharacterChanged();
                }
            }
        }

        public static void AuthorizeNewCharacter()
        {
            var verificationWindow = new VerificationWindow(ESI.EsiData.EsiClient);
            verificationWindow.ShowDialog();

            var duplicateCharacter =
                CharacterManager.CharacterList.SingleOrDefault(
                    c => c.CharacterDetails.CharacterName == verificationWindow.Character.CharacterDetails.CharacterName);
            if (duplicateCharacter != null)
            {
                var dialogResult = MessageBox.Show($"{duplicateCharacter.CharacterDetails.CharacterName} is already added!", "", MessageBoxButton.OK);
                return;
            }

            CharacterManager.CharacterList.Add(verificationWindow.Character);
            CharacterManager.CurrentInstance.OnCharactersChanged();
        }

        public event EventHandler SelectedCharacterChanged;
        protected virtual void OnSelectedCharacterChanged()
        {
            SelectedCharacterChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CharactersChanged;
        protected virtual void OnCharactersChanged()
        {
            CharactersChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
