using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Bookmarks API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Bookmarks : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Bookmarks>();

        internal Bookmarks(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// A list of your character’s personal bookmarks.
        /// <para>GET /characters/{character_id}/bookmarks/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bookmarks.</returns>
        public async Task<ESIModelDTO<List<Bookmark>>> ListBookmarksV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_BOOKMARKS_READ_CHARACTER_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/bookmarks/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListBookmarksV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Bookmark>>(responseModel);
        }

        /// <summary>
        /// A list of your character’s personal bookmark folders.
        /// <para>GET /characters/{character_id}/bookmarks/folders/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bookmark folders.</returns>
        public async Task<ESIModelDTO<List<BookmarkFolder>>> ListBookmarkFoldersV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_BOOKMARKS_READ_CHARACTER_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/bookmarks/folders/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListBookmarkFoldersV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<BookmarkFolder>>(responseModel);
        }

        /// <summary>
        /// A list of your corporation’s bookmarks.
        /// <para>GET /corporations/{corporation_id}/bookmarks/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation owned bookmarks.</returns>
        public async Task<ESIModelDTO<List<Bookmark>>> ListCorporationBookmarksV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_BOOKMARKS_READ_CORPORATION_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporation/{corporationId}/bookmarks/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListCorporationBookmarksV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Bookmark>>(responseModel);
        }

        /// <summary>
        /// A list of your corporation’s bookmark folders.
        /// <para>GET /corporations/{corporation_id}/bookmarks/folders/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation owned bookmark folders.</returns>
        public async Task<ESIModelDTO<List<BookmarkFolder>>> ListCorporationBookmarkFoldersV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_BOOKMARKS_READ_CORPORATION_BOOKMARKS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporation/{corporationId}/bookmarks/folders/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(ListCorporationBookmarkFoldersV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<BookmarkFolder>>(responseModel);
        }
    }
}
