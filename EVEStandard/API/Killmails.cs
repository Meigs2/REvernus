using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Killmails API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Killmails : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Killmails>();

        internal Killmails(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return a single killmail from its ID and hash.
        /// <para>GET /killmails/{killmail_id}/{killmail_hash}/</para>
        /// </summary>
        /// <param name="killmailId">The killmail ID to be queried.</param>
        /// <param name="killmailHash">The killmail hash for verification.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a killmail.</returns>
        public async Task<ESIModelDTO<Killmail>> GetKillmailV1Async(int killmailId, string killmailHash, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/killmails/{killmailId}/{killmailHash}/", ifNoneMatch);

            CheckResponse(nameof(GetKillmailV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Killmail>(responseModel);
        }

        /// <summary>
        /// Return a list of a character’s kills and losses going back 90 days.
        /// <para>GET /characters/{character_id}/killmails/recent/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of killmail IDs and hashes.</returns>
        public async Task<ESIModelDTO<List<KillmailIndex>>> GetCharacterKillsAndLossesV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_KILLMAILS_READ_KILLMAILS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/killmails/recent/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterKillsAndLossesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<KillmailIndex>>(responseModel);
        }

        /// <summary>
        /// Get a list of a corporation’s kills and losses going back 90 days.
        /// <para>GET /corporations/{corporation_id}/killmails/recent/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of killmail IDs and hashes.</returns>
        public async Task<ESIModelDTO<List<KillmailIndex>>> GetCorporationKillsAndLossesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_KILLMAILS_READ_CORPORATION_KILLMAILS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/killmails/recent/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationKillsAndLossesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<KillmailIndex>>(responseModel);
        }
    }
}
