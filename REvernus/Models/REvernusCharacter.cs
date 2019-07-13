using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EVEStandard.Models;
using EVEStandard.Models.API;
using EVEStandard.Models.SSO;
using Prism.Mvvm;
using REvernus.Core;
using REvernus.Core.ESI;

namespace REvernus.Models
{
    public class REvernusCharacter
    {
        public AccessTokenDetails AccessTokenDetails { get; set; } = new AccessTokenDetails();
        public CharacterDetails CharacterDetails { get; set; } = new CharacterDetails();
        public string CharacterName => CharacterDetails.CharacterName;
        public DateTime AuthExpiration => AccessTokenDetails.ExpiresUtc;

        public async Task<List<CharacterMarketOrder>> GetCharacterMarketOrdersAsync()
        {
            var result = await EsiData.EsiClient.Market.ListOpenOrdersFromCharacterV2Async(
                new AuthDTO()
                {
                    AccessToken = AccessTokenDetails,
                    CharacterId = CharacterDetails.CharacterId,
                    Scopes = EVEStandard.Enumerations.Scopes.ESI_MARKETS_READ_CHARACTER_ORDERS_1
                });
            return result.Model;
        }
    }
}
