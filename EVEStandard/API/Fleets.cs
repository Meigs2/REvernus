using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Fleets API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Fleets : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Fleets>();

        internal Fleets(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return details about a fleet.
        /// <para>GET /fleets/{fleet_id}</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a fleet.</returns>
        public async Task<ESIModelDTO<FleetInfo>> GetFleetInfoV1Async(AuthDTO auth, long fleetId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await GetAsync($"/v1/fleets/{fleetId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetFleetInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FleetInfo>(responseModel);
        }

        /// <summary>
        /// Update settings about a fleet.
        /// <para>PUT /fleets/{fleet_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="motd">New fleet MOTD in CCP flavoured HTML.</param>
        /// <param name="isFreeMove">Should free-move be enabled in the fleet.</param>
        /// <returns></returns>
        public async Task UpdateFleetV1Async(AuthDTO auth, long fleetId, string motd, bool? isFreeMove)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var newSettings = new
            {
                motd,
                is_free_move = isFreeMove
            };

            var responseModel = await PutAsync($"/v1/fleets/{fleetId}/", auth, newSettings);

            CheckResponse(nameof(UpdateFleetV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return the fleet ID the character is in, if any.
        /// <para>GET /characters/{character_id}/fleet/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about the character’s fleet.</returns>
        public async Task<ESIModelDTO<CharacterFleetInfo>> GetCharacterFleetInfoV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/fleet/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterFleetInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterFleetInfo>(responseModel);
        }

        /// <summary>
        /// Return information about fleet members.
        /// <para>GET /fleets/{fleet_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value: en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet members.</returns>
        public async Task<ESIModelDTO<List<FleetMember>>> GetFleetMembersV1Async(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ?? Language.English }
            };

            var responseModel = await GetAsync($"/v1/fleets/{fleetId}/members/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetFleetMembersV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FleetMember>>(responseModel);
        }

        /// <summary>
        /// Invite a character into the fleet. If a character has a CSPA charge set it is not possible to invite them to the fleet using ESI.
        /// <para>POST /fleets/{fleet_id}/members/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="invite">Details of the invitation.</param>
        /// <returns></returns>
        public async Task CreateFleetInvitationV1Async(AuthDTO auth, long fleetId, FleetInvitation invite)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync($"/v1/fleets/{fleetId}/members/", auth, invite);

            CheckResponse(nameof(CreateFleetInvitationV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Kick a fleet member.
        /// <para>DELETE /fleets/{fleet_id}/members/{member_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="memberId">The character ID of a member in this fleet.</param>
        /// <returns></returns>
        public async Task KickFleetMemberV1Async(AuthDTO auth, long fleetId, int memberId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync($"/v1/fleets/{fleetId}/members/{memberId}/", auth);

            CheckResponse(nameof(KickFleetMemberV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Move a fleet member around.
        /// <para>PUT /fleets/{fleet_id}/members/{member_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="memberId">The character ID of a member in this fleet.</param>
        /// <param name="movement">Details of the invitation.</param>
        /// <returns></returns>
        public async Task MoveFleetMemberV1Async(AuthDTO auth, long fleetId, int memberId, FleetMemberMove movement)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PutAsync($"/v1/fleets/{fleetId}/members/{memberId}/", auth, movement);

            CheckResponse(nameof(MoveFleetMemberV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return information about wings in a fleet.
        /// <para>GET /fleets/{fleet_id}/wings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value: en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet wings.</returns>
        public async Task<ESIModelDTO<List<FleetWing>>> GetFleetWingsV1Async(AuthDTO auth, long fleetId, string language = Language.English, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_READ_FLEET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ?? Language.English }
            };

            var responseModel = await GetAsync($"/v1/fleets/{fleetId}/wings/", auth, ifNoneMatch);

            CheckResponse(nameof(GetFleetWingsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<FleetWing>>(responseModel);
        }

        /// <summary>
        /// Create a new wing in a fleet.
        /// <para>POST /fleets/{fleet_id}/wings/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet wing ids.</returns>
        public async Task<ESIModelDTO<long>> CreateFleetWingV1Async(AuthDTO auth, long fleetId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync($"/v1/fleets/{fleetId}/wings/", auth, null);

            CheckResponse(nameof(CreateFleetWingV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Delete a fleet wing, only empty wings can be deleted. The wing may contain squads, but the squads must be empty.
        /// <para>DELETE /fleets/{fleet_id}/wings/{wing_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="wingId">The wing to delete.</param>
        /// <returns></returns>
        public async Task DeleteFleetWingV1Async(AuthDTO auth, long fleetId, long wingId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync($"/v1/fleets/{fleetId}/wings/{wingId}/", auth);

            CheckResponse(nameof(DeleteFleetWingV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Rename a fleet wing
        /// <para>PUT /fleets/{fleet_id}/wings/{wing_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="wingId">The wing to delete.</param>
        /// <param name="name">New name of the wing.</param>
        /// <returns></returns>
        public async Task RenameFleetWingV1Async(AuthDTO auth, long fleetId, long wingId, string name)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name
            };

            var responseModel = await PutAsync($"/v1/fleets/{fleetId}/wings/{wingId}/", auth, body);

            CheckResponse(nameof(RenameFleetWingV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Create a new squad in a fleet.
        /// <para>POST /fleets/{fleet_id}/wings/{wing_id}/squads/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of fleet squad ids.</returns>
        public async Task<ESIModelDTO<long>> CreateFleetSquadV1Async(AuthDTO auth, long fleetId, long wingId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await PostAsync($"/v1/fleets/{fleetId}/wings/{wingId}/squads/", auth, null);

            CheckResponse(nameof(CreateFleetSquadV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<long>(responseModel);
        }

        /// <summary>
        /// Delete a fleet squad, only empty squads can be deleted.
        /// <para>DELETE /fleets/{fleet_id}/squads/{squad_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="squadId">The squad to delete.</param>
        /// <returns></returns>
        public async Task DeleteFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var responseModel = await DeleteAsync($"/v1/fleets/{fleetId}/squads/{squadId}/", auth);

            CheckResponse(nameof(DeleteFleetSquadV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Rename a fleet squad.
        /// <para>PUT /fleets/{fleet_id}/squads/{squad_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fleetId">ID for a fleet.</param>
        /// <param name="squadId">The squad to delete.</param>
        /// <param name="name">New name of the squad.</param>
        /// <returns></returns>
        public async Task RenameFleetSquadV1Async(AuthDTO auth, long fleetId, long squadId, string name)
        {
            CheckAuth(auth, Scopes.ESI_FLEETS_WRITE_FLEET_1);

            var body = new
            {
                name
            };

            var responseModel = await PutAsync($"/v1/fleets/{fleetId}/squads/{squadId}/", auth, body);

            CheckResponse(nameof(RenameFleetSquadV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }
    }
}
