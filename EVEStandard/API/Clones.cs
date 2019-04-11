using EVEStandard.Enumerations;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Clones API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Clones : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Clones>();

        internal Clones(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// A list of the character’s clones.
        /// <para>GET /characters/{character_id}/clones/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing clone information for the given character.</returns>
        public async Task<ESIModelDTO<Clones>> GetClonesV3Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CLONES_READ_CLONES_1);

            var responseModel = await GetAsync($"/v3/characters/{auth.CharacterId}/clones/", auth, ifNoneMatch);

            CheckResponse(nameof(GetClonesV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<Clones>(responseModel);
        }

        /// <summary>
        /// Return implants on the active clone of a character.
        /// <para>GET /characters/{character_id}/implants/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of implant type ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetActiveImplantsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CLONES_READ_IMPLANTS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/implants/", auth, ifNoneMatch);

            CheckResponse(nameof(GetActiveImplantsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }
    }
}
