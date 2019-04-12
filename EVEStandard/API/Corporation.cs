using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Corporation API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Corporation : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Corporation>();

        internal Corporation(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return the current shareholders of a corporation.
        /// <para>GET /corporations/{corporation_id}/shareholders/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of shareholders.</returns>
        public async Task<ESIModelDTO<List<Shareholder>>> GetCorporationShareholdersV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/shareholders/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationShareholdersV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Shareholder>>(responseModel);
        }

        /// <summary>
        /// Public information about a corporation.
        /// <para>GET /corporations/{corporation_id}/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public information about a corporation.</returns>
        public async Task<ESIModelDTO<CorporationInfo>> GetCorporationInfoV4Async(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v4/corporations/{corporationId}/", ifNoneMatch);

            CheckResponse(nameof(GetCorporationInfoV4Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationInfo>(responseModel);
        }

        /// <summary>
        /// Get a list of all the alliances a corporation has been a member of.
        /// <para>GET /corporations/{corporation_id}/alliancehistory/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing alliance history for the given corporation.</returns>
        public async Task<ESIModelDTO<List<AllianceHistory>>> GetAllianceHistoryV2Async(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v2/corporations/{corporationId}/alliancehistory/", ifNoneMatch);

            CheckResponse(nameof(GetAllianceHistoryV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AllianceHistory>>(responseModel);
        }

        /// <summary>
        /// Return the current member list of a corporation, the token’s character need to be a member of the corporation.
        /// <para>GET /corporations/{corporation_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character IDs.</returns>
        public async Task<ESIModelDTO<List<int>>> GetCorporationMembersV3Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await GetAsync($"/v3/corporations/{corporationId}/members/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationMembersV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Return the roles of all members if the character has the personnel manager role or any grantable role.
        /// <para>GET /corporations/{corporation_id}/roles/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character ID’s and roles.</returns>
        public async Task<ESIModelDTO<List<CorporationRoles>>> GetCorporationMemberRolesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/roles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationMemberRolesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationRoles>>(responseModel);
        }

        /// <summary>
        /// Return how roles have changed for a coporation’s members, up to a month.
        /// <para>GET /corporations/{corporation_id}/roles/history/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of role changes.</returns>
        public async Task<ESIModelDTO<List<CorporationRoleHistory>>> GetCorporationMemberRolesHistoryV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CORPORATION_MEMBERSHIP_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/roles/history/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationMemberRolesHistoryV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationRoleHistory>>(responseModel);
        }

        /// <summary>
        /// Get the icon urls for a corporation.
        /// <para>GET /corporations/{corporation_id}/icons/</para>
        /// </summary>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing urls for icons for the given corporation id and server.</returns>
        public async Task<ESIModelDTO<Icons>> GetCorporationIconV1Async(int corporationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/icons/", ifNoneMatch);

            CheckResponse(nameof(GetCorporationIconV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Icons>(responseModel);
        }

        /// <summary>
        /// Get a list of npc corporations.
        /// <para>GET /corporations/npccorps/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of npc corporation ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetNPCCorporationsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/corporations/npccorps/", ifNoneMatch);

            CheckResponse(nameof(GetNPCCorporationsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get a list of corporation structures.
        /// <para>GET /corporations/{corporation_id}/structures/</para>
        /// <para>Requires one of the following EVE corporation role(s): StationManager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation structures’ information.</returns>
        public async Task<ESIModelDTO<List<CorporationStructure>>> GetCorporationStructuresV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STRUCTURES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/corporations/{corporationId}/structures/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationStructuresV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationStructure>>(responseModel);
        }

        /// <summary>
        /// Returns additional information about a corporation’s members which helps tracking their activities.
        /// <para>GET /corporations/{corporation_id}/membertracking/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of member character IDs.</returns>
        public async Task<ESIModelDTO<List<CorporationMemberTracking>>> TrackCorporationMembersV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/membertracking/", auth, ifNoneMatch);

            CheckResponse(nameof(TrackCorporationMembersV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMemberTracking>>(responseModel);
        }

        /// <summary>
        /// Return corporation hangar and wallet division names, only show if a division is not using the default name.
        /// <para>GET /corporations/{corporation_id}/divisions/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation division names.</returns>
        public async Task<ESIModelDTO<CorporationDivision>> GetCorporationDivisionsV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/divisions/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationDivisionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CorporationDivision>(responseModel);
        }

        /// <summary>
        /// Return a corporation’s member limit, not including CEO himself.
        /// <para>GET /corporations/{corporation_id}/members/limit/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the corporation’s member limit.</returns>
        public async Task<ESIModelDTO<int>> GetCorporationMemberLimitV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_TRACK_MEMBERS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/members/limit/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationMemberLimitV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<int>(responseModel);
        }

        /// <summary>
        /// Returns a corporation’s titles.
        /// <para>GET /corporations/{corporation_id}/titles/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of titles.</returns>
        public async Task<ESIModelDTO<List<CorporationTitle>>> GetCorporationTitlesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/titles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationTitlesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationTitle>>(responseModel);
        }

        /// <summary>
        /// Returns a corporation’s members’ titles.
        /// <para>GET /corporations/{corporation_id}/members/titles/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of members and theirs titles.</returns>
        public async Task<ESIModelDTO<List<CorporationMemberTitles>>> GetCorporationsMembersTitlesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_TITLES_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/members/titles/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationsMembersTitlesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMemberTitles>>(responseModel);
        }

        /// <summary>
        /// Returns a list of blueprints the corporation owns.
        /// <para>GET /corporations/{corporation_id}/blueprints/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation blueprints.</returns>
        public async Task<ESIModelDTO<List<Blueprint>>> GetCorporationBlueprintsV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_BLUEPRINTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/corporations/{corporationId}/blueprints/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationBlueprintsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Blueprint>>(responseModel);
        }

        /// <summary>
        /// Return corporation standings from agents, NPC corporations, and factions.
        /// <para>GET /corporations/{corporation_id}/standings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of standings.</returns>
        public async Task<ESIModelDTO<List<Standing>>> GetStandingsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STANDINGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/standings/", auth, ifNoneMatch);

            CheckResponse(nameof(GetStandingsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Standing>>(responseModel);
        }

        /// <summary>
        /// Returns list of corporation starbases (POSes).
        /// <para>GET /corporations/{corporation_id}/starbases/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of starbases (POSes).</returns>
        public async Task<ESIModelDTO<List<Starbase>>> GetCorporationStarbasesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/starbases/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationStarbasesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Starbase>>(responseModel);
        }

        /// <summary>
        /// Returns various settings and fuels of a starbase (POS).
        /// <para>GET /corporations/{corporation_id}/starbases/{starbase_id}/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="starbaseId">An EVE starbase (POS) ID.</param>
        /// <param name="systemId">The solar system this starbase (POS) is located in.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of starbases (POSes).</returns>
        public async Task<ESIModelDTO<StarbaseDetail>> GetStarbaseDetailV1Async(AuthDTO auth, int corporationId, long starbaseId, long systemId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_STARBASES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "system_id", systemId.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/starbases/{starbaseId}/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetStarbaseDetailV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<StarbaseDetail>(responseModel);
        }

        /// <summary>
        /// Returns logs recorded in the past seven days from all audit log secure containers (ALSC) owned by a given corporation.
        /// <para>GET /corporations/{corporation_id}/containers/logs/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation ALSC logs.</returns>
        public async Task<ESIModelDTO<List<ContainerLogs>>> GetAllCorporationALSCLogsV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTAINER_LOGS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/corporations/{corporationId}/containers/logs/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetAllCorporationALSCLogsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContainerLogs>>(responseModel);
        }

        /// <summary>
        /// Return a corporation’s facilities.
        /// <para>GET /corporations/{corporation_id}/facilities/</para>
        /// <para>Requires one of the following EVE corporation role(s): Factory_Manager</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation facilities.</returns>
        public async Task<ESIModelDTO<List<Facility>>> GetCorporationFacilitiesV1Async(AuthDTO auth, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_FACILITIES_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/facilities/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationFacilitiesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Facility>>(responseModel);
        }

        /// <summary>
        /// Returns a corporation’s medals.
        /// <para>GET /corporations/{corporation_id}/medals/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of medals.</returns>
        public async Task<ESIModelDTO<List<CorporationMedal>>> GetCorporationMedalsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/medals/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationMedalsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMedal>>(responseModel);
        }

        /// <summary>
        /// Returns medals issued by a corporation.
        /// <para>GET /corporations/{corporation_id}/medals/issued/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of issued medals.</returns>
        public async Task<ESIModelDTO<List<CorporationMedalIssued>>> GetCorporationIssuedMedalsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_MEDALS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/medals/issued/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationIssuedMedalsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationMedalIssued>>(responseModel);
        }
    }
}
