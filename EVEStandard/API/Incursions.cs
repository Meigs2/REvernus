using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Incursions API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Incursions : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Incursions>();

        internal Incursions(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return a list of current incursions.
        /// <para>GET /incursions/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of incursions.</returns>
        public async Task<ESIModelDTO<List<Models.Incursion>>> ListIncursionsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/incursions/", ifNoneMatch);

            CheckResponse(nameof(ListIncursionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Models.Incursion>>(responseModel);
        }
    }
}
