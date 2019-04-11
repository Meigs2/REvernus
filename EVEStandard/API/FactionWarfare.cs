using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Faction Warfare API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class FactionWarfare : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<FactionWarfare>();

        internal FactionWarfare(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Data about which NPC factions are at war.
        /// <para>GET /fw/wars/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of NPC factions at war.</returns>
        public async Task<ESIModelDTO<List<FactionWarData>>> DataAboutFactionWarsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/wars/", ifNoneMatch);

            CheckResponse(nameof(DataAboutFactionWarsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FactionWarData>>(responseModel);
        }

        /// <summary>
        /// Statistical overviews of factions involved in faction warfare.
        /// <para>GET /fw/stats/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing per faction breakdown of faction warfare statistics.</returns>
        public async Task<ESIModelDTO<List<FactionWarStats>>> StatsAboutFactionWarsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/stats/", ifNoneMatch);

            CheckResponse(nameof(StatsAboutFactionWarsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FactionWarStats>>(responseModel);
        }

        /// <summary>
        /// An overview of the current ownership of faction warfare solar systems.
        /// <para>GET /fw/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing all faction warfare solar systems.</returns>
        public async Task<ESIModelDTO<List<FactionWarSystem>>> FactionWarSystemOwnershipV2Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v2/fw/systems/", ifNoneMatch);

            CheckResponse(nameof(FactionWarSystemOwnershipV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FactionWarSystem>>(responseModel);
        }

        /// <summary>
        /// Top 4 leaderboard of factions for kills and victory points separated by total, last week and yesterday.
        /// <para>GET /fw/leaderboards/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing faction leaderboard of kills and victory points within faction warfare.</returns>
        public async Task<ESIModelDTO<FactionWarFactionLeaderboard>> TopFactionsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/", ifNoneMatch);

            CheckResponse(nameof(TopFactionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FactionWarFactionLeaderboard>(responseModel);
        }

        /// <summary>
        /// Top 100 leaderboard of pilots for kills and victory points separated by total, last week and yesterday.
        /// <para>GET /fw/leaderboards/characters/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing character leaderboard of kills and victory points within faction warfare.</returns>
        public async Task<ESIModelDTO<FactionWarPilotLeaderboard>> TopPilotsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/characters/", ifNoneMatch);

            CheckResponse(nameof(TopPilotsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FactionWarPilotLeaderboard>(responseModel);
        }

        /// <summary>
        /// Top 10 leaderboard of corporations for kills and victory points separated by total, last week and yesterday.
        /// <para>GET /fw/leaderboards/corporations/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing corporation leaderboard of kills and victory points within faction warfare.</returns>
        public async Task<ESIModelDTO<FactionWarCorporationLeaderboard>> TopCorporationsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/fw/leaderboards/corporations/", ifNoneMatch);

            CheckResponse(nameof(TopCorporationsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FactionWarCorporationLeaderboard>(responseModel);
        }

        /// <summary>
        /// Statistics about a corporation involved in faction warfare.
        /// <para>GET /corporations/{corporation_id}/fw/stats/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing faction warfare statistics for a given corporation.</returns>
        public async Task<ESIModelDTO<FactionWarCorporationStats>> CorporationOverviewInFactionWarsV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_FW_STATS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/fw/stats/", ifNoneMatch);

            CheckResponse(nameof(CorporationOverviewInFactionWarsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FactionWarCorporationStats>(responseModel);
        }

        /// <summary>
        /// Statistical overview of a character involved in faction warfare.
        /// <para>GET /characters/{character_id}/fw/stats/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing faction warfare statistics for a given character.</returns>
        public async Task<ESIModelDTO<FactionWarCharacterStats>> CharacterOverviewInFactionWarsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_FW_STATS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/fw/stats/", ifNoneMatch);

            CheckResponse(nameof(CharacterOverviewInFactionWarsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FactionWarCharacterStats>(responseModel);
        }
    }
}
