using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Insurance API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Insurance : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Insurance>();

        internal Insurance(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return available insurance levels for all ship types.
        /// <para>GET /insurance/prices/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of insurance levels for all ship types.</returns>
        public async Task<ESIModelDTO<List<InsurancePrice>>> ListInsuranceLevelsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/insurance/prices/", ifNoneMatch);

            CheckResponse(nameof(ListInsuranceLevelsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<InsurancePrice>>(responseModel);
        }
    }
}
