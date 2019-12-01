using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Wars API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Wars : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Wars>();

        internal Wars(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return a list of wars.
        /// <para>GET /wars/</para>
        /// </summary>
        /// <param name="maxWarId">Only return wars with ID smaller than this.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of war IDs, in decending order by war_id.</returns>
        public async Task<ESIModelDTO<List<int>>> ListWarsV1Async(int? maxWarId, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "max_war_id", maxWarId?.ToString() }
            };

            var responseModel = await GetAsync("/v1/wars/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListWarsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Return details about a war.
        /// <para>GET /wars/{war_id}/</para>
        /// </summary>
        /// <param name="warId">ID for a war.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a war.</returns>
        public async Task<ESIModelDTO<War>> GetWarInformationV1Async(int warId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/wars/{warId}/", ifNoneMatch);

            CheckResponse(nameof(GetWarInformationV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<War>(responseModel);
        }

        /// <summary>
        /// Return a list of kills related to a war.
        /// <para>GET /wars/{war_id}/killmails/</para>
        /// </summary>
        /// <param name="warId">A valid war ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of killmail IDs and hashes.</returns>
        public async Task<ESIModelDTO<List<KillmailIndex>>> ListKillsForWarV1Async(int warId, int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/wars/{warId}/killmails/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListKillsForWarV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<KillmailIndex>>(responseModel);
        }
    }
}
