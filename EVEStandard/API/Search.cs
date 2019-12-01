using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Search API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Search : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Search>();

        internal Search(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Search for entities that match a given sub-string.
        /// <para>GET /characters/{character_id}/search/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="categories">Type of entities to search for. Available values : agent, alliance, character, constellation, corporation, faction, inventory_type, region, solar_system, station, structure.</param>
        /// <param name="search">The string to search on.</param>
        /// <param name="strict">Whether the search should be a strict match. Default value : false.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of search results.</returns>
        public async Task<ESIModelDTO<CharacterSearch>> SearchCharacterV3Async(AuthDTO auth, List<string> categories, string search, bool strict = false, string language = Language.English, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_SEARCH_SEARCH_STRUCTURES_1);

            if (categories == null || categories.Count == 0 || search == null)
            {
                throw new ArgumentNullException();
            }

            var queryParameters = new Dictionary<string, string>
            {
                { "categories", string.Join(",", categories) },
                { "language", language },
                { "search", search },
                { "strict", strict.ToString() }
            };

            var responseModel = await GetAsync($"/v3/characters/{auth.CharacterId}/search/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(SearchCharacterV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterSearch>(responseModel);
        }

        /// <summary>
        /// Search for entities that match a given sub-string.
        /// </summary>
        /// <param name="categories">Type of entities to search for. Available values : agent, alliance, character, constellation, corporation, faction, inventory_type, region, solar_system, station, structure.</param>
        /// <param name="search">The string to search on.</param>
        /// <param name="strict">Whether the search should be a strict match. Default value : false.</param>
        /// <param name="language">Language to use in the response, takes precedence over Accept-Language. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of search results.</returns>
        public async Task<ESIModelDTO<Models.Search>> SearchV2Async(List<string> categories, string search, bool strict = false, string language = Language.English, string ifNoneMatch = null)
        {
            if (categories == null || categories.Count == 0 || search == null)
            {
                throw new ArgumentNullException();
            }

            var queryParameters = new Dictionary<string, string>
            {
                { "categories", string.Join(",", categories) },
                { "language", language },
                { "search", search },
                { "strict", strict.ToString() }
            };

            var responseModel = await GetAsync("/v2/search/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(SearchV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.Search>(responseModel);
        }
    }
}
