using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Dogma API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Dogma : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Dogma>();

        internal Dogma(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Get a list of dogma attribute ids.
        /// <para>GET /dogma/attributes</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of dogma attribute ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetAttributesV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/dogma/attributes/", ifNoneMatch);

            CheckResponse(nameof(GetAttributesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a dogma attribute.
        /// <para>GET /dogma/attributes/{attribute_id}/</para>
        /// </summary>
        /// <param name="attributeId">A dogma attribute ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a dogma attribute.</returns>
        public async Task<ESIModelDTO<DogmaAttribute>> GetAttributeInfoV1Async(int attributeId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/dogma/attributes/{attributeId}/", ifNoneMatch);

            CheckResponse(nameof(GetAttributeInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<DogmaAttribute>(responseModel);
        }

        /// <summary>
        /// Returns info about a dynamic item resulting from mutation with a mutaplasmid.
        /// <para>GET /dogma/dynamic/items/{type_id}/{item_id}/</para>
        /// </summary>
        /// <param name="typeId">The type identifier.</param>
        /// <param name="itemId">The item identifier.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details about a dynamic item.</returns>
        public async Task<ESIModelDTO<DogmaDynamicItem>> GetDynamicItemInfoV1Async(int typeId, long itemId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/dogma/dynamic/items/{typeId}/{itemId}/", ifNoneMatch);

            CheckResponse(nameof(GetDynamicItemInfoV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<DogmaDynamicItem>(responseModel);
        }

        /// <summary>
        /// Get a list of dogma effect ids.
        /// <para>GET /dogma/effects/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of dogma effect ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetEffectsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/dogma/effects/", ifNoneMatch);

            CheckResponse(nameof(GetEffectsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Get information on a dogma effect.
        /// <para>GET /dogma/effects/{effect_id}</para>
        /// </summary>
        /// <param name="effectId">A dogma effect ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing information about a dogma effect.</returns>
        public async Task<ESIModelDTO<DogmaEffect>> GetEffectInfoV2Async(int effectId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v2/dogma/effects/{effectId}/", ifNoneMatch);

            CheckResponse(nameof(GetEffectInfoV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<DogmaEffect>(responseModel);
        }
    }
}
