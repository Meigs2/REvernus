using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Planetary Interaction API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class PlanetaryInteraction : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<PlanetaryInteraction>();

        internal PlanetaryInteraction(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Returns a list of all planetary colonies owned by a character.
        /// <para>GET /characters/{character_id}/planets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of colonies.</returns>
        public async Task<ESIModelDTO<List<Colony>>> GetColoniesV1Async(AuthDTO auth, string ifNoneMatch=null)
        {
            CheckAuth(auth, Scopes.ESI_PLANETS_MANAGE_PLANETS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/planets/", auth, ifNoneMatch);

            CheckResponse(nameof(GetColoniesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Colony>>(responseModel);
        }

        /// <summary>
        /// Returns full details on the layout of a single planetary colony, including links, pins and routes. 
        /// Note: Planetary information is only recalculated when the colony is viewed through the client. 
        /// Information will not update until this criteria is met.
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="planetId">Planet id of the target planet.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a colony layout.</returns>
        public async Task<ESIModelDTO<ColonyLayout>> GetColonyLayoutV3Async(AuthDTO auth, int planetId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_PLANETS_MANAGE_PLANETS_1);

            var responseModel = await GetAsync($"/v3/characters/{auth.CharacterId}/planets/{planetId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetColonyLayoutV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<ColonyLayout>(responseModel);
        }

        /// <summary>
        /// Get information on a planetary factory schematic.
        /// <para>GET /universe/schematics/{schematic_id}/</para>
        /// </summary>
        /// <param name="schematicId">A PI schematic ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing public data about a schematic.</returns>
        public async Task<ESIModelDTO<FactorySchematic>> GetSchematicInfoV1Async(int schematicId, string ifNoneMatch=null)
        {
            var responseModel = await GetAsync($"/v1/universe/schematics/{schematicId}/", ifNoneMatch);

            CheckResponse(nameof(GetSchematicInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<FactorySchematic>(responseModel);
        }

        /// <summary>
        /// Lists the corporation customs offices v1 asynchronous.
        /// <para>GET /corporations/{corporation_id}/customs_offices/</para>
        /// <para>Requires one of the following EVE corporation role(s): Director</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">The corporation identifier.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of customs offices and their settings.</returns>
        public async Task<ESIModelDTO<List<CustomsOffice>>> ListCorporationCustomsOfficesV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch=null)
        {
            CheckAuth(auth, Scopes.ESI_PLANETS_READ_CUSTOMS_OFFICES_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/customs_offices/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListCorporationCustomsOfficesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CustomsOffice>>(responseModel);
        }
    }
}
