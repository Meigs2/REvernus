using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Loyalty API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Loyalty : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Loyalty>();

        internal Loyalty(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return a list of offers from a specific corporation’s loyalty store.
        /// <para>GET /loyalty/stores/{corporation_id}/offers/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of offers.</returns>
        public async Task<ESIModelDTO<List<LoyaltyStoreOffer>>> ListLoyaltyStoreOffersV1Async(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/loyalty/stores/{corporationId}/offers/", ifNoneMatch);

            CheckResponse(nameof(ListLoyaltyStoreOffersV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<LoyaltyStoreOffer>>(responseModel);
        }

        /// <summary>
        /// Return a list of loyalty points for all corporations the character has worked for.
        /// <para>GET /characters/{character_id}/loyalty/points/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of loyalty points.</returns>
        public async Task<ESIModelDTO<List<LoyaltyPoints>>> GetLoyaltyPointsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_LOYALTY_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/loyalty/points/", auth, ifNoneMatch);

            CheckResponse(nameof(GetLoyaltyPointsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<LoyaltyPoints>>(responseModel);
        }
    }
}
