using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Skills API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Skills : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Skills>();

        internal Skills(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// List all trained skills for the given character.
        /// <para>GET characters/{character_id}/skills/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing known skills for the character.</returns>
        public async Task<ESIModelDTO<CharacterSkills>> GetCharacterSkillsV4Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_SKILLS_READ_SKILLS_1);

            var responseModel = await GetAsync($"/v4/characters/{auth.CharacterId}/skills/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterSkillsV4Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterSkills>(responseModel);
        }

        /// <summary>
        /// Return attributes of a character.
        /// <para>GET /characters/{character_id}/attributes/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing attributes of a character.</returns>
        public async Task<ESIModelDTO<CharacterAttributes>> GetCharacterAttributesV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_SKILLS_READ_SKILLS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/attributes/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterAttributesV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<CharacterAttributes>(responseModel);
        }

        /// <summary>
        /// List the configured skill queue for the given character.
        /// <para>GET /characters/{character_id}/skillqueue/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing the current skill queue, sorted ascending by finishing time.</returns>
        public async Task<ESIModelDTO<List<SkillQueue>>> GetCharacterSkillQueueV2Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_SKILLS_READ_SKILLQUEUE_1);

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/skillqueue/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterSkillQueueV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<SkillQueue>>(responseModel);
        }
    }
}
