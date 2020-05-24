using EVEStandard.Enumerations;
using log4net;
using REvernus.Core.ESI;
using REvernus.Database.Contexts;
using REvernus.Database.UserDbModels;
using REvernus.Models;
using REvernus.Views.SimpleViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace REvernus.Core
{
    public sealed class AuthProvider
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        private readonly Timer _authRefreshTimer = new Timer
        { Interval = TimeSpan.FromMinutes(10).TotalMilliseconds, AutoReset = true };

        private List<REvernusCharacter> _characterList;

        public AuthProvider()
        {
            _characterList = new List<REvernusCharacter>();

            _authRefreshTimer.Elapsed += AuthRefreshTimer_Elapsed;
            _authRefreshTimer.Enabled = true;

            Initialized += CharacterManager_Initialized;

            OnInitialized();
        }

        private async void CharacterManager_Initialized(object sender, EventArgs e)
        {
            // Load characters from Database into the AuthProvider
            await LoadCharactersFromDb();
        }
        private async void AuthRefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await RefreshAuths();
        }

        private async Task LoadCharactersFromDb()
        {
            await using var userContext = new UserContext();
            var refreshTokens = userContext.Characters.Select(o => o.RefreshToken).ToList();

            _characterList = new List<REvernusCharacter>();

            foreach (var refreshToken in refreshTokens)
            {
                var character = new REvernusCharacter
                {
                    AccessTokenDetails =
                        await EsiData.EsiClient.SSO.GetRefreshTokenAsync(refreshToken)
                };
                character.CharacterDetails =
                    await EsiData.EsiClient.SSO.GetCharacterDetailsAsync(character.AccessTokenDetails.AccessToken);
                _characterList.Add(character);
            }
        }

        public void AuthorizeNewCharacter()
        {
            var verificationWindow = new VerificationWindow(EsiData.EsiClient);
            verificationWindow.ShowDialog();

            var duplicateCharacter =
                _characterList.SingleOrDefault(
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

            // Add the new character to the database.
            using var userContext = new UserContext();
            var character = new CharacterInformation
            {
                CharacterId = verificationWindow.Character.CharacterDetails.CharacterId,
                CharacterName = verificationWindow.Character.CharacterName,
                RefreshToken = verificationWindow.Character.AccessTokenDetails.RefreshToken
            };
            userContext.Characters.Add(character);
            userContext.SaveChanges();

            _characterList.Add(verificationWindow.Character);

            OnCharactersChanged();
        }

        public void RemoveCharacters(List<REvernusCharacter> characters)
        {
            foreach (var character in characters)
            {
                EsiData.EsiClient.SSO.RevokeTokenAsync(RevokeType.REFRESH_TOKEN,
                    character.AccessTokenDetails.AccessToken);
                EsiData.EsiClient.SSO.RevokeTokenAsync(RevokeType.ACCESS_TOKEN,
                    character.AccessTokenDetails.AccessToken);
                _characterList.Remove(character);

                using var userContext = new UserContext();
                var characterInformation = userContext.Characters.First(e => e.CharacterId == character.CharacterDetails.CharacterId);
                userContext.Remove(characterInformation);
                userContext.SaveChanges();
            }
            OnCharactersChanged();
        }

        public async Task RefreshAuths()
        {
            var taskList = _characterList.Select(character => Task.Run(async () =>
                {
                    await using var userContext = new UserContext();
                    var result =
                        await EsiData.EsiClient.SSO.GetRefreshTokenAsync(character.AccessTokenDetails.RefreshToken);
                    character.AccessTokenDetails = result;

                    var dbCharacter =
                        userContext.Characters.First(c => c.CharacterId == character.CharacterDetails.CharacterId);
                    dbCharacter.RefreshToken = character.AccessTokenDetails.RefreshToken;
                    await userContext.SaveChangesAsync();
                }))
                .ToList();
            await Task.WhenAll(taskList);
        }

        public event EventHandler SelectedCharacterChanged;

        private void OnSelectedCharacterChanged()
        {
            SelectedCharacterChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CharactersChanged;

        private void OnCharactersChanged()
        {
            CharactersChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Initialized;

        private void OnInitialized()
        {
            Initialized?.Invoke(this, EventArgs.Empty);
        }
    }
}