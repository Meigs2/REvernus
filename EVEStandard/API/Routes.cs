using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Routes API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Routes : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Routes>();

        internal Routes(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Get the systems between origin and destination.
        /// <para>GET /route/{origin}/{destination}/</para>
        /// </summary>
        /// <param name="origin">Origin solar system ID.</param>
        /// <param name="destination">Destination solar system ID.</param>
        /// <param name="avoidSystems">Avoid solar system ID(s).</param>
        /// <param name="connections">Connected solar system pairs.</param>
        /// <param name="flag">Route security preference. Available values : shortest, secure, insecure. Default value: shortest.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing solar systems in route from origin to destination.</returns>
        public async Task<ESIModelDTO<List<int>>> GetRouteV1Async(int origin, int destination, List<int> avoidSystems = null, List<int> connections = null, string flag=RoutePreference.SHORTEST, string ifNoneMatch=null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "avoid", avoidSystems == null || avoidSystems.Count == 0 ? "" : string.Join(",", avoidSystems) },
                { "connections", connections == null || connections.Count == 0 ? "" : string.Join(",", connections) },
                { "flag", flag }
            };

            var responseModel = await GetAsync($"/v1/route/{origin}/{destination}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetRouteV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }
    }
}
