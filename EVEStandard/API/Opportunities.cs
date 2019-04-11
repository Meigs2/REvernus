using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Opportunities API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Opportunities : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Opportunities>();

        internal Opportunities(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return a list of opportunities groups.
        /// <para>GET /opportunities/groups/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of opportunities group ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetOpportunitiesGroupsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/opportunities/groups/", ifNoneMatch);

            CheckResponse(nameof(GetOpportunitiesGroupsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Return information of an opportunities group.
        /// <para>GET /opportunities/groups/{group_id}/</para>
        /// </summary>
        /// <param name="groupId">ID of an opportunities group.</param>
        /// <param name="language">Language to use in the response. Available values : de, en-us, fr, ja, ru, zh. Default value : en-us.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details of an opportunities group.</returns>
        public async Task<ESIModelDTO<OpportunitiesGroup>> GetOpportunitiesGroupV1Async(int groupId, string language = Language.English, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "language", language ??Language.English }
            };

            var responseModel = await GetAsync($"/v1/opportunities/groups/{groupId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetOpportunitiesGroupV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<OpportunitiesGroup>(responseModel);
        }

        /// <summary>
        /// Return a list of opportunities tasks.
        /// <para>GET /opportunities/tasks/</para>
        /// </summary>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of opportunities task ids.</returns>
        public async Task<ESIModelDTO<List<int>>> GetOpportunitiesTasksV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/opportunities/tasks/", ifNoneMatch);

            CheckResponse(nameof(GetOpportunitiesTasksV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Return information of an opportunities task.
        /// </summary>
        /// <param name="taskId">ID of an opportunities task.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing details of an opportunities task.</returns>
        public async Task<ESIModelDTO<OpportunitiesTask>> GetOpportunitiesTaskV1Async(int taskId, string ifNoneMatch = null)
        {
            var responseModel = await GetAsync($"/v1/opportunities/tasks/{taskId}/", ifNoneMatch);

            CheckResponse(nameof(GetOpportunitiesTaskV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<OpportunitiesTask>(responseModel);
        }

        /// <summary>
        /// Return a list of tasks finished by a character.
        /// <para>GET /characters/{character_id}/opportunities/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of opportunities task ids.</returns>
        public async Task<ESIModelDTO<List<CharacterTask>>> GetCharacterCompletedTaskV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_OPPORTUNITIES_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/opportunities/", ifNoneMatch);

            CheckResponse(nameof(GetCharacterCompletedTaskV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterTask>>(responseModel);
        }
    }
}
