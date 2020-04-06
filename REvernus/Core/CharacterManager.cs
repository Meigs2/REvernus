using Prism.Mvvm;
using REvernus.Core.ESI;
using REvernus.Models;
using REvernus.Models.SerializableModels;
using REvernus.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using REvernus.Views.SimpleViews;

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
        public static REvernusCharacter SelectedCharacter
        {
            get => CurrentInstance._selectedCharacter ??= new REvernusCharacter();
            set
            {
                if (value != CurrentInstance._selectedCharacter)
                {
                    CurrentInstance.SetProperty(ref _currentInstance._selectedCharacter, value);
                    App.Settings.CharacterManagerSettings.SelectedCharacterName = value.CharacterName;
                    CurrentInstance.OnSelectedCharacterChanged();
                }
            }
        }

        public static AuthDTO PublicAuthDto => new AuthDTO()
        {
            AccessToken = SelectedCharacter.AccessTokenDetails,
            CharacterId = SelectedCharacter.CharacterDetails.CharacterId,
            Scopes = Scopes.ESI_UNIVERSE_READ_STRUCTURES_1
        };

        private CharacterManager()
        {
            _authRefreshTimer.Elapsed += AuthRefreshTimer_Elapsed;
            _authRefreshTimer.Enabled = true;
        }

        private async void AuthRefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
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

            if (verificationWindow.Character.CharacterName == "")
                return;

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
        }

        private static async Task<ObservableCollection<REvernusCharacter>> GenerateCharacterList(List<string> refreshTokenList)
        {
            try
            {
                var charList = new List<REvernusCharacter>();
                foreach (var refreshToken in refreshTokenList)
                {
                    var character = new REvernusCharacter
                    {
                        AccessTokenDetails =
                            await EsiData.EsiClient.SSOv2.GetRefreshTokenAsync(refreshToken)
                    };
                    character.CharacterDetails =
                        EsiData.EsiClient.SSOv2.GetCharacterDetailsAsync(character.AccessTokenDetails.AccessToken);
                    charList.Add(character);
                }
                return new ObservableCollection<REvernusCharacter>(charList);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
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
