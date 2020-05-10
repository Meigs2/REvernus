namespace REvernus.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows;

    using log4net;

    using Prism.Mvvm;

    using REvernus.Core.ESI;
    using REvernus.Database.Contexts;
    using REvernus.Database.UserDbModels;
    using REvernus.Models;
    using REvernus.Views.SimpleViews;

    public sealed class CharacterManager : BindableBase
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private readonly Timer _authRefreshTimer = new Timer
            { Interval = TimeSpan.FromMinutes(10).TotalMilliseconds, AutoReset = true };

        private ObservableCollection<REvernusCharacter> _characterList;

        private REvernusCharacter _selectedCharacter = new REvernusCharacter();

        public CharacterManager()
        {
            _authRefreshTimer.Elapsed += AuthRefreshTimer_Elapsed;
            _authRefreshTimer.Enabled = true;

            CharactersChanged += CharacterManager_CharactersChanged;

            Initialized += CharacterManager_Initialized;

            OnInitialized();
        }

        public ObservableCollection<REvernusCharacter> CharacterList
        {
            get => _characterList ??= new ObservableCollection<REvernusCharacter>();
            set
            {
                if (value != _characterList)
                {
                    SetProperty(ref _characterList, value);
                    OnCharactersChanged();
                }
            }
        }

        public REvernusCharacter SelectedCharacter
        {
            get => _selectedCharacter ??= new REvernusCharacter();
            set
            {
                if (value != _selectedCharacter)
                {
                    SetProperty(ref _selectedCharacter, value);
                    if (App.Settings != null)
                        App.Settings.CharacterManagerSettings.SelectedCharacterName =
                            value == null ? "" : value.CharacterName;
                    else
                    {
                        throw new ArgumentException("App.Settings is null");
                    }
                    OnSelectedCharacterChanged();
                }
            }
        }

        public void AuthorizeNewCharacter()
        {
            var verificationWindow = new VerificationWindow(EsiData.EsiClient);
            verificationWindow.ShowDialog();

            var duplicateCharacter =
                CharacterList.SingleOrDefault(
                    c => c.CharacterDetails.CharacterName ==
                         verificationWindow.Character.CharacterDetails.CharacterName);

            if (duplicateCharacter != null)
            {
                MessageBox.Show($"{duplicateCharacter.CharacterDetails.CharacterName} is already added!", "",
                    MessageBoxButton.OK);
                return;
            }

            if (verificationWindow.Character.CharacterName == "")
                return;

            CharacterList.Add(verificationWindow.Character);
            OnCharactersChanged();
        }

        public event EventHandler CharactersChanged;

        public event EventHandler Initialized;

        public async Task RefreshAllCharacterAuth()
        {
            var taskList = new List<Task>();
            foreach (var character in CharacterList)
            {
                taskList.Add(Task.Run(async () =>
                {
                    var result =
                        await EsiData.EsiClient.SSO.GetRefreshTokenAsync(character.AccessTokenDetails.RefreshToken);
                    character.AccessTokenDetails = result;
                }));
            }

            await Task.WhenAll(taskList);
            OnCharactersChanged();
        }

        public void RemoveCharacters(List<REvernusCharacter> characters)
        {
            foreach (var rEvernusCharacter in characters)
            {
                CharacterList.Remove(rEvernusCharacter);
            }

            OnCharactersChanged();
        }

        public event EventHandler SelectedCharacterChanged;

        private async void AuthRefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await RefreshAllCharacterAuth();
        }

        private void CharacterManager_CharactersChanged(object sender, EventArgs e)
        {
            // Whenever Characters are changed, update the database.
            using var userContext = new UserContext();
            userContext.Characters.RemoveRange(userContext.Characters.Select(o => o));
            foreach (var rEvernusCharacter in CharacterList)
            {
                var character = new CharacterInformation
                {
                    CharacterId = rEvernusCharacter.CharacterDetails.CharacterId,
                    CharacterName = rEvernusCharacter.CharacterName,
                    RefreshToken = rEvernusCharacter.AccessTokenDetails.RefreshToken
                };
                userContext.Characters.Add(character);
            }

            userContext.SaveChanges();
        }

        private async void CharacterManager_Initialized(object sender, EventArgs e)
        {
            // Load characters from Database
            CharacterList = await LoadCharactersFromDb();
        }

        private static async Task<ObservableCollection<REvernusCharacter>> GenerateCharacterList(
            List<string> refreshTokenList)
        {
            try
            {
                var charList = new List<REvernusCharacter>();
                foreach (var refreshToken in refreshTokenList)
                {
                    var character = new REvernusCharacter
                    {
                        AccessTokenDetails =
                            await EsiData.EsiClient.SSO.GetRefreshTokenAsync(refreshToken)
                    };
                    character.CharacterDetails =
                        await EsiData.EsiClient.SSO.GetCharacterDetailsAsync(character.AccessTokenDetails.AccessToken);
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

        private async Task<ObservableCollection<REvernusCharacter>> LoadCharactersFromDb()
        {
            await using var userContext = new UserContext();
            var characters = userContext.Characters.Select(o => o.RefreshToken).ToList();

            return await GenerateCharacterList(characters);
        }

        private void OnCharactersChanged()
        {
            CharactersChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnInitialized()
        {
            Initialized?.Invoke(this, EventArgs.Empty);
        }

        private void OnSelectedCharacterChanged()
        {
            SelectedCharacterChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}