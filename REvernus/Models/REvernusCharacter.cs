namespace REvernus.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EVEStandard.Enumerations;
    using EVEStandard.Models;
    using EVEStandard.Models.API;
    using EVEStandard.Models.SSO;

    using REvernus.Core.ESI;

    public class REvernusCharacter
    {
        public AccessTokenDetails AccessTokenDetails { get; set; } = new AccessTokenDetails();
        public DateTime AuthExpiration => AccessTokenDetails.ExpiresUtc;
        public CharacterDetails CharacterDetails { get; set; } = new CharacterDetails();
        public string CharacterName => CharacterDetails.CharacterName;

        public async Task<List<CharacterMarketOrder>> GetCharacterMarketOrdersAsync()
        {
            var result = await EsiData.EsiClient.Market.ListOpenOrdersFromCharacterV2Async(
                new AuthDTO
                {
                    AccessToken = AccessTokenDetails,
                    CharacterId = CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1
                });
            return result.Model;
        }

        public async Task OpenMarketWindow(int typeId)
        {
            await EsiData.EsiClient.UserInterface.OpenMarketDetailsV1Async(
                new AuthDTO
                {
                    AccessToken = AccessTokenDetails,
                    CharacterId = CharacterDetails.CharacterId,
                    Scopes = Scopes.ESI_UI_OPEN_WINDOW_1
                }, typeId);
        }
    }
}