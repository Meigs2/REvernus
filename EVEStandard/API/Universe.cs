using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Station = EVEStandard.Models.Station;

namespace EVEStandard.API
{
    /// <summary>
    /// Universe API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Universe : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Universe>();

        internal Universe(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Get all character ancestries.
        /// <para>GET /universe/ancestries/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of ancestries.</returns>
        public async Task<ESIModelDTO<List<Ancestry>>> GetAncestriesV1Async(string language = Language.English, string ifNoneMatch=null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/ancestries/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetAncestriesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Ancestry>>(responseModel);
        }

        /// <summary>
        /// Get information on an asteroid belt.
        /// <para>GET /universe/asteroid_belts/{asteroid_belt_id}/</para>
        /// </summary>
        /// <param name="asteroidBeltId">The asteroid belt identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an asteroid belt.</returns>
        public async Task<ESIModelDTO<AsteroidBelt>> GetAsteroidBeltV1Async(int asteroidBeltId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/universe/asteroid_belts/{asteroidBeltId}/", ifNoneMatch);

            CheckResponse(nameof(GetAsteroidBeltV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<AsteroidBelt>(responseModel);
        }

        /// <summary>
        /// Get a list of bloodlines.
        /// <para>GET /universe/bloodlines/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bloodlines.</returns>
        public async Task<ESIModelDTO<List<Bloodline>>> GetBloodlinesV1Async(string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/bloodlines/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetBloodlinesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Bloodline>>(responseModel);
        }

        /// <summary>
        /// Get a list of item categories.
        /// <para>GET /universe/categories/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item category ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetItemCategoriesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/universe/categories/", ifNoneMatch);

            CheckResponse(nameof(GetItemCategoriesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information of an item category.
        /// <para>GET /universe/categories/{category_id}/</para>
        /// </summary>
        /// <param name="categoryId">An Eve item category ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about an item category.</returns>
        public async Task<ESIModelDTO<Category>> GetItemCategoryInfoV1Async(int categoryId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/categories/{categoryId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemCategoryInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Category>(responseModel);
        }

        /// <summary>
        /// Get a list of constellations.
        /// <para>GET /universe/constellations/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of constellation ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetConstellationsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/universe/constellations/", ifNoneMatch);

            CheckResponse(nameof(GetConstellationsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a constellation.
        /// <para>GET /universe/constellations/{constellation_id}/</para>
        /// </summary>
        /// <param name="constellationId">The constellation identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a constellation.</returns>
        public async Task<ESIModelDTO<Constellation>> GetConstellationV1Async(int constellationId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/constellations/{constellationId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetConstellationV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Constellation>(responseModel);
        }

        /// <summary>
        /// Get a list of factions.
        /// <para>GET /universe/factions/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        public async Task<ESIModelDTO<List<Faction>>> GetFactionsV2Async(string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync(" /v2/universe/factions/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetFactionsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Faction>>(responseModel);
        }

        /// <summary>
        /// Get a list of graphics.
        /// <para>GET /universe/graphics/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of graphic ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetGraphicsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/universe/graphics/", ifNoneMatch);

            CheckResponse(nameof(GetGraphicsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a graphic.
        /// <para>GET /universe/graphics/{graphic_id}/</para>
        /// </summary>
        /// <param name="graphicId">The graphic identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a graphic.</returns>
        public async Task<ESIModelDTO<Graphic>> GetGraphicV1Async(int graphicId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/universe/graphics/{graphicId}/", ifNoneMatch);

            CheckResponse(nameof(GetGraphicV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Graphic>(responseModel);
        }

        /// <summary>
        /// Get a list of item groups.
        /// <para>GET /universe/groups</para>
        /// </summary>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of item group ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetItemGroupsV1Async(int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/universe/groups/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemGroupsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on an item group.
        /// <para>GET /universe/groups/{group_id}/</para>
        /// </summary>
        /// <param name="groupId">An Eve item group ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        public async Task<ESIModelDTO<Group>> GetItemGroupV1Async(int groupId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/groups/{groupId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetItemGroupV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Group>(responseModel);
        }

        /// <summary>
        /// Resolve a set of names to IDs in the following categories: agents, alliances, characters, constellations, corporations factions, inventory_types, regions, stations, and systems. 
        /// Only exact matches will be returned. All names searched for are cached for 12 hours.
        /// <para>POST /universe/ids/</para>
        /// </summary>
        /// <param name="names">The names to resolve.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of factions.</returns>
        public async Task<ESIModelDTO<Models.Universe>> BulkNamesToIdsV1Async(List<string> names, string language = Language.English)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await PostAsync("/v1/universe/ids/", null, names, null, queryParameters);

            CheckResponse(nameof(BulkNamesToIdsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.Universe>(responseModel);
        }

        /// <summary>
        /// Get information on a moon.
        /// <para>GET /universe/moons/{moon_id}/</para>
        /// </summary>
        /// <param name="moonId">The moon identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a moon.</returns>
        public async Task<ESIModelDTO<Moon>> GetMoonInfoV1Async(long moonId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/universe/moons/{moonId}/", ifNoneMatch);

            CheckResponse(nameof(GetItemGroupsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Moon>(responseModel);
        }

        /// <summary>
        /// Resolve a set of IDs to names and categories. Supported ID’s for resolving are: Characters, Corporations, Alliances, Stations, Solar Systems, Constellations, Regions, Types.
        /// <para>POST /universe/names/</para>
        /// </summary>
        /// <param name="ids">The ids to resolve.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of id/name associations for a set of ID’s. All ID’s must resolve to a name, or nothing will be returned.</returns>
        public async Task<ESIModelDTO<List<UniverseIdsToNames>>> GetNamesAndCategoriesFromIdsV2Async(List<int> ids)
        {
            var responseModel = await PostAsync("/v2/universe/names/", null, ids);

            CheckResponse(nameof(GetNamesAndCategoriesFromIdsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<UniverseIdsToNames>>(responseModel);
        }

        /// <summary>
        /// Get information on a planet.
        /// <para>GET /universe/planets/{planet_id}/</para>
        /// </summary>
        /// <param name="planetId">The planet identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a planet.</returns>
        public async Task<ESIModelDTO<Planet>> GetPlanetInfoV1Async(long planetId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/universe/planets/{planetId}/", ifNoneMatch);

            CheckResponse(nameof(GetPlanetInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Planet>(responseModel);
        }

        /// <summary>
        /// Get a list of character races.
        /// <para>GET /universe/races/</para>
        /// </summary>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of character races.</returns>
        public async Task<ESIModelDTO<List<Race>>> GetCharacterRacesV1Async(string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync("/v1/universe/races/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterRacesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Race>>(responseModel);
        }

        /// <summary>
        /// Get a list of regions.
        /// <para>GET /universe/regions</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of region ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetRegionsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/universe/regions/", ifNoneMatch);

            CheckResponse(nameof(GetRegionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a region.
        /// <para>GET /universe/regions/{region_id}/</para>
        /// </summary>
        /// <param name="regionId">The region identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a region.</returns>
        public async Task<ESIModelDTO<Region>> GetRegionInfoV1Async(int regionId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v1/universe/regions/{regionId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetRegionInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Region>(responseModel);
        }

        /// <summary>
        /// Get information on a stargate.
        /// <para>GET /universe/stargates/{stargate_id}/</para>
        /// </summary>
        /// <param name="stargateId">The stargate identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a region.</returns>
        public async Task<ESIModelDTO<Stargate>> GetStargateInfoV1Async(int stargateId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/universe/stargates/{stargateId}/", ifNoneMatch);

            CheckResponse(nameof(GetStargateInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Stargate>(responseModel);
        }

        /// <summary>
        /// Get information on a star.
        /// <para>GET /universe/stars/{star_id}/</para>
        /// </summary>
        /// <param name="starId">The star identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a star.</returns>
        public async Task<ESIModelDTO<Star>> GetStarInfoV1Async(int starId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/universe/stars/{starId}/", ifNoneMatch);

            CheckResponse(nameof(GetStarInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Star>(responseModel);
        }

        /// <summary>
        /// Get information on a station.
        /// <para>GET /universe/structures/</para>
        /// </summary>
        /// <param name="stationId">The station identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a station.</returns>
        public async Task<ESIModelDTO<Station>> GetStationInfoV2Async(int stationId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v2/universe/stations/{stationId}/", ifNoneMatch);

            CheckResponse(nameof(GetStationInfoV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Station>(responseModel);
        }

        /// <summary>
        /// List all public structures.
        /// <para>GET /universe/structures</para>
        /// </summary>
        /// <param name="filter">Optional param to return structures that only have a market or basic manufacturing.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of public structure IDs.</returns>
        public async Task<ESIModelDTO<List<long>>> ListAllPublicStructuresV1Async(StructureHas filter, string ifNoneMatch = null)
        {
            APIResponse responseModel;
            if (filter == StructureHas.NoFilter)
            {
                responseModel = await GetAsync("/v1/universe/structures/", ifNoneMatch);
            }
            else
            {
                var queryParameters = new Dictionary<string, string>
                {
                    {"filter", filter == StructureHas.Market ? "market" : "manufacturing_basic" }
                };

                responseModel = await GetAsync("/v1/universe/structures/", ifNoneMatch, queryParameters);
            }

            CheckResponse(nameof(ListAllPublicStructuresV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<long>>(responseModel);
        }

        /// <summary>
        /// Returns information on requested structure, if you are on the ACL. Otherwise, returns “Forbidden” for all inputs.
        /// <para>GET /universe/structures/{structure_id}/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="structureId">An Eve structure ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing data about a structure.</returns>
        public async Task<ESIModelDTO<Structure>> GetStructureInfoV2Async(AuthDTO auth, long structureId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_UNIVERSE_READ_STRUCTURES_1);

            var responseModel = await GetAsync($"/v2/universe/structures/{structureId}/", auth, ifNoneMatch);

            CheckResponse(nameof(GetStructureInfoV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Structure>(responseModel);
        }

        /// <summary>
        /// Get the number of jumps in solar systems within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. Only systems with jumps will be listed.
        /// <para>GET /universe/system_jumps/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of systems and number of jumps.</returns>
        public async Task<ESIModelDTO<List<SystemJumps>>> GetSystemJumpsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/universe/system_jumps/", ifNoneMatch);

            CheckResponse(nameof(GetSystemJumpsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SystemJumps>>(responseModel);
        }

        /// <summary>
        /// Get the number of ship, pod and NPC kills per solar system within the last hour ending at the timestamp of the Last-Modified header, excluding wormhole space. Only systems with kills will be listed.
        /// <para>GET /universe/system_kills/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of systems and number of ship, pod and NPC kills.</returns>
        public async Task<ESIModelDTO<List<SystemKills>>> GetSystemKillsV2Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v2/universe/system_kills/", ifNoneMatch);

            CheckResponse(nameof(GetSystemKillsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SystemKills>>(responseModel);
        }

        /// <summary>
        /// Get a list of solar systems.
        /// <para>GET /universe/systems/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of solar system ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetSolarSystemsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/universe/systems/", ifNoneMatch);

            CheckResponse(nameof(GetSolarSystemsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a solar system. NOTE: This route does not work with abyssal systems.
        /// <para>GET /universe/systems/{system_id}/</para>
        /// </summary>
        /// <param name="systemId">The system identifier.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a solar system.</returns>
        public async Task<ESIModelDTO<Models.System>> GetSolarSystemInfoV4Async(int systemId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v4/universe/systems/{systemId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetSolarSystemInfoV4Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.System>(responseModel);
        }

        /// <summary>
        /// Get a list of type ids.
        /// <para>GET /universe/types</para>
        /// </summary>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of type ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetTypesV1Async(int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/universe/types/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetTypesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a type.
        /// <para>GET /universe/types/{type_id}/</para>
        /// </summary>
        /// <param name="typeId">An Eve item type ID.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a type.</returns>
        public async Task<ESIModelDTO<Type>> GetTypeInfoV3Async(int typeId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                {"language", language}
            };

            var responseModel = await GetAsync($"/v3/universe/types/{typeId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetTypeInfoV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Type>(responseModel);
        }

        public enum StructureHas
        {
            NoFilter,
            Market,
            ManufacturingBasic
        }
    }
}