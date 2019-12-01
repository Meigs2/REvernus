using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Status API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Status : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Status>();

        internal Status(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// EVE Server status.
        /// <para>GET /status/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing server status.</returns>
        public async Task<ESIModelDTO<Models.Status>> GetStatusV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/status/", ifNoneMatch);

            CheckResponse(nameof(GetStatusV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Models.Status>(responseModel);
        }
    }
}
