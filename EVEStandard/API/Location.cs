using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Location API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Location : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Location>();

        internal Location(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Information about the characters current location. Returns the current solar system id, and also the current station or structure ID if applicable.
        /// <para>GET /characters/{character_id}/location/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about the characters current location. Returns the current solar system id, and also the current station or structure ID if applicable.</returns>
        public async Task<ESIModelDTO<CharacterLocation>> GetCharacterLocationV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_LOCATION_READ_LOCATION_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/location/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterLocationV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterLocation>(responseModel);
        }

        /// <summary>
        /// Get the current ship type, name and id.
        /// <para>GET /characters/{character_id}/ship/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the current ship type, name and id.</returns>
        public async Task<ESIModelDTO<CharacterShip>> GetCurrentShipV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_LOCATION_READ_SHIP_TYPE_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/ship/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCurrentShipV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterShip>(responseModel);
        }

        /// <summary>
        /// Checks if the character is currently online.
        /// <para>GET /characters/{character_id}/online/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing object describing the character’s online status.</returns>
        public async Task<ESIModelDTO<CharacterOnline>> GetCharacterOnlineV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_LOCATION_READ_ONLINE_1);

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/online/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterOnlineV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterOnline>(responseModel);
        }
    }
}
