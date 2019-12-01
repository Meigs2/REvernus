using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Sovereignty API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Sovereignty : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Sovereignty>();

        internal Sovereignty(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Shows sovereignty data for structures.
        /// <para>GET /sovereignty/structures/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of sovereignty structures.</returns>
        public async Task<ESIModelDTO<List<SovereigntyStructure>>> ListSovereigntyStructuresV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/sovereignty/structures/", ifNoneMatch);

            CheckResponse(nameof(ListSovereigntyStructuresV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SovereigntyStructure>>(responseModel);
        }

        /// <summary>
        /// Shows sovereignty data for campaigns.
        /// <para>GET /sovereignty/campaigns/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of sovereignty campaigns.</returns>
        public async Task<ESIModelDTO<List<SovereigntyCampaign>>> ListSovereigntyCampaignsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/sovereignty/campaigns/", ifNoneMatch);

            CheckResponse(nameof(ListSovereigntyCampaignsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SovereigntyCampaign>>(responseModel);
        }

        /// <summary>
        /// Shows sovereignty information for solar systems.
        /// <para>GET /sovereignty/map/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of sovereignty information for solar systems in New Eden.</returns>
        public async Task<ESIModelDTO<List<SovereigntyMap>>> ListSovereigntyOfSystemsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/sovereignty/map/", ifNoneMatch);

            CheckResponse(nameof(ListSovereigntyOfSystemsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SovereigntyMap>>(responseModel);
        }
    }
}
