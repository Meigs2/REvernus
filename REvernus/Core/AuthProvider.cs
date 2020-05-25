using EVEStandard.Enumerations;
using log4net;
using REvernus.Core.ESI;
using REvernus.Database.Contexts;
using REvernus.Database.UserDbModels;
using REvernus.Models;
using REvernus.Views.SimpleViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public AuthProvider()
        {
            CharacterList = new ObservableCollection<REvernusCharacter>();
        }

        public ObservableCollection<REvernusCharacter> CharacterList { get; }

        private async void AuthRefreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await RefreshAuths();
        }

        /// <summary>
        ///     Loads characters from user.db and refreshes their auth.
        /// </summary>
        /// <returns></returns>
        public async Task Initialize()
        {
            await using var userContext = new UserContext();
            var refreshTokens = userContext.Characters.Select(o => o.RefreshToken).ToList();

            foreach (var refreshToken in refreshTokens)
            {
                var character = new REvernusCharacter
                {
                    AccessTokenDetails =
                        await EsiData.EsiClient.SSO.GetRefreshTokenAsync(refreshToken)
                };
                character.CharacterDetails =
                    await EsiData.EsiClient.SSO.GetCharacterDetailsAsync(character.AccessTokenDetails.AccessToken);
                CharacterList.Add(character);
            }

            _authRefreshTimer.Elapsed += AuthRefreshTimer_Elapsed;
            _authRefreshTimer.Enabled = true;
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

            CharacterList.Add(verificationWindow.Character);
        }

        public void RemoveCharacters(List<REvernusCharacter> characters)
        {
            foreach (var character in characters)
            {
                EsiData.EsiClient.SSO.RevokeTokenAsync(RevokeType.REFRESH_TOKEN,
                    character.AccessTokenDetails.AccessToken);
                EsiData.EsiClient.SSO.RevokeTokenAsync(RevokeType.ACCESS_TOKEN,
                    character.AccessTokenDetails.AccessToken);
                CharacterList.Remove(character);

                using var userContext = new UserContext();
                var characterInformation =
                    userContext.Characters.First(e => e.CharacterId == character.CharacterDetails.CharacterId);
                userContext.Remove(characterInformation);
                userContext.SaveChanges();
            }
        }

        public async Task RefreshAuths()
        {
            var taskList = CharacterList.Select(character => Task.Run(async () =>
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

        public REvernusCharacter GetCharacterById(long characterId)
        {
            return CharacterList.FirstOrDefault(c => c.CharacterDetails.CharacterId == characterId);
        }

        public REvernusCharacter GetCharacterByName(string characterName)
        {
            return CharacterList.FirstOrDefault(c => c.CharacterDetails.CharacterName == characterName);
        }
    }
}