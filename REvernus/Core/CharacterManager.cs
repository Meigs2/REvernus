using Prism.Mvvm;
using REvernus.Core.CharacterManagement;
using REvernus.Core.ESI;
using REvernus.Models;
using REvernus.Models.SerializableModels;
using REvernus.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace REvernus.Core
{
    public class CharacterManager : BindableBase
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static CharacterManager _currentInstance;
        public static CharacterManager CurrentInstance
        {
            get { return _currentInstance ??= new CharacterManager(); }
        }

        private ObservableCollection<REvernusCharacter> _characterList;

        public static ObservableCollection<REvernusCharacter> CharacterList
        {
            get => CurrentInstance._characterList ??= new ObservableCollection<REvernusCharacter>();
            set
            {
                if (value != CurrentInstance._characterList)
                {
                    CurrentInstance.SetProperty(ref _currentInstance._characterList, value);
                    CurrentInstance.OnCharactersChanged();
                }
            }
        }

        private REvernusCharacter _selectedCharacter = new REvernusCharacter();
        public REvernusCharacter SelectedCharacter
        {
            get => CurrentInstance._selectedCharacter ??= new REvernusCharacter();
            set
            {
                if (value != CurrentInstance._selectedCharacter)
                {
                    CurrentInstance.SetProperty(ref _currentInstance._selectedCharacter, value);
                    CurrentInstance.OnSelectedCharacterChanged();
                }
            }
        }

        private CharacterManager()
        {
            _authRefreshTimer.Elapsed += _authRefreshTimer_Elapsed;
            _authRefreshTimer.Enabled = true;
        }

        private async void _authRefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await RefreshAllCharacterAuth();
        }

        #region Public Methods and Events

        public static void AuthorizeNewCharacter()
        {
            var verificationWindow = new VerificationWindow(EsiData.EsiClient);
            verificationWindow.ShowDialog();

            var duplicateCharacter =
                CharacterList.SingleOrDefault(
                    c => c.CharacterDetails.CharacterName == verificationWindow.Character.CharacterDetails.CharacterName);
            if (duplicateCharacter != null)
            {
                MessageBox.Show($"{duplicateCharacter.CharacterDetails.CharacterName} is already added!", "", MessageBoxButton.OK);
                return;
            }

            CharacterList.Add(verificationWindow.Character);

            CurrentInstance.OnCharactersChanged();
        }

        public static void RemoveCharacters(List<REvernusCharacter> characters)
        {
            foreach (var rEvernusCharacter in characters)
            {
                CharacterList.Remove(rEvernusCharacter);
            }
        }

        private readonly Timer _authRefreshTimer = new Timer()
        { Interval = TimeSpan.FromMinutes(10).TotalMilliseconds, AutoReset = true };
        public static async Task RefreshAllCharacterAuth()
        {
            var taskList = new List<Task>();
            foreach (var character in CharacterList)
            {
                taskList.Add(EsiData.EsiClient.SSOv2.GetRefreshTokenAsync(character.AccessTokenDetails.RefreshToken));
            }
            await Task.WhenAll(taskList);
            Log.Info("Successfully refreshed all character's auth.");
        }

        public static void SerializeCharacters()
        {
            var serializableList = new List<SerializableCharacter>();
            foreach (var character in CharacterList)
            {
                serializableList.Add(new SerializableCharacter() { RefreshToken = character.AccessTokenDetails.RefreshToken });
            }
            Serializer.SerializeData(serializableList, System.IO.Path.Combine(Environment.CurrentDirectory, "Characters.bin"));
        }

        public static async Task DeserializeCharacters()
        {
            var serializedCharacterList = Serializer.DeserializeData<List<SerializableCharacter>>(System.IO.Path.Combine(
                Environment.CurrentDirectory, "Characters.bin"));

            if (serializedCharacterList == null) return;

            try
            {
                var charList = new List<REvernusCharacter>();
                foreach (var serializableCharacter in serializedCharacterList)
                {
                    var character = new REvernusCharacter
                    {
                        AccessTokenDetails =
                            await EsiData.EsiClient.SSOv2.GetRefreshTokenAsync(serializableCharacter.RefreshToken)
                    };
                    character.CharacterDetails =
                        EsiData.EsiClient.SSOv2.GetCharacterDetailsAsync(character.AccessTokenDetails.AccessToken);
                    charList.Add(character);
                }

                CharacterList = new ObservableCollection<REvernusCharacter>(charList);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
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

        #endregion

        #region Private Methods, Events, and grouped things, like timers and their initializers.

        #endregion
    }
}
