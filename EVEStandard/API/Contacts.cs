using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Contacts API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Contacts : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Contacts>();

        internal Contacts(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Bulk delete contacts.
        /// <para>DELETE /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contactIds">A list of contacts to delete.</param>
        /// <returns></returns>
        public async Task DeleteContactsV2Async(AuthDTO auth, List<int> contactIds)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "contact_ids", contactIds == null || contactIds.Count == 0 ? "" : string.Join(",", contactIds) }
            };

            var responseModel = await DeleteAsync($"/v2/characters/{auth.CharacterId}/contacts/", auth, queryParameters);

            CheckResponse(nameof(DeleteContactsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return contacts of a character.
        /// <para>GET /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contacts.</returns>
        public async Task<ESIModelDTO<List<CharacterContact>>> GetContactsV2Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/characters/{auth.CharacterId}/contacts/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetContactsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterContact>>(responseModel);
        }

        /// <summary>
        /// Bulk add contacts with same settings.
        /// <para>POST /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contactIds">A list of contacts.</param>
        /// <param name="labelIds">Add custom labels to the new contact.</param>
        /// <param name="standing">Standing for the contact.</param>
        /// <param name="isWatched">Whether the contact should be watched, note this is only effective on characters Default value: false.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact ids that successfully created.</returns>
        public async Task<ESIModelDTO<List<int>>> AddContactsV2Async(AuthDTO auth, List<int> contactIds, List<long> labelIds, float standing, bool isWatched=false)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "label_ids", labelIds == null || labelIds.Count == 0 ? "" : string.Join(",", labelIds) },
                { "standing", standing.ToString() },
                { "watched", isWatched.ToString() }
            };

            var responseModel = await PostAsync($"/v2/characters/{auth.CharacterId}/contacts/", auth, contactIds, null, queryParameters);

            CheckResponse(nameof(AddContactsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<int>>(responseModel);
        }

        /// <summary>
        /// Bulk edit contacts with same settings.
        /// <para>PUT /characters/{character_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contactIds">A list of contacts.</param>
        /// <param name="labelIds">Add custom labels to the new contact.</param>
        /// <param name="standing">Standing for the contact.</param>
        /// <param name="isWatched">Whether the contact should be watched, note this is only effective on characters Default value: false.</param>
        /// <returns></returns>
        public async Task EditContactsV2Async(AuthDTO auth, List<int> contactIds, List<long> labelIds, float standing, bool isWatched=false)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_WRITE_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "label_ids", labelIds == null || labelIds.Count == 0 ? "" : string.Join(",", labelIds) },
                { "standing", standing.ToString() },
                { "watched", isWatched.ToString() }
            };

            var responseModel = await PutAsync($"/v2/characters/{auth.CharacterId}/contacts/", auth, contactIds, queryParameters);

            CheckResponse(nameof(EditContactsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Return contacts of a corporation.
        /// <para>GET /corporations/{corporation_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contacts.</returns>
        public async Task<ESIModelDTO<List<CorporationContact>>> GetCorporationContactsV2Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/corporations/{corporationId}/contacts/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationContactsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationContact>>(responseModel);
        }

        /// <summary>
        /// Return contacts of an alliance.
        /// <para>/alliances/{alliance_id}/contacts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="allianceId">An EVE alliance ID.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contacts.</returns>
        public async Task<ESIModelDTO<List<AllianceContact>>> GetAllianceContactsV2Async(AuthDTO auth, int allianceId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ALLIANCE_READ_CONTACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v2/alliances/{allianceId}/contacts/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetAllianceContactsV2Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<AllianceContact>>(responseModel);
        }

        /// <summary>
        /// Return custom labels for a character’s contacts.
        /// <para>GET /characters/{character_id}/contacts/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contact labels.</returns>
        public async Task<ESIModelDTO<List<ContactLabel>>> GetContactLabelsV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CHARACTERS_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/contacts/labels/", auth, ifNoneMatch);

            CheckResponse(nameof(GetContactLabelsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContactLabel>>(responseModel);
        }

        /// <summary>
        /// Return custom labels for an alliance’s contacts.
        /// <para>GET /alliances/{alliance_id}/contacts/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of alliance contact labels.</returns>
        public async Task<ESIModelDTO<List<ContactLabel>>> GetAllianceContactLabelsV1Async(AuthDTO auth, int allianceId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_ALLIANCE_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v1/alliances/{allianceId}/contacts/labels/", auth, ifNoneMatch);

            CheckResponse(nameof(GetAllianceContactLabelsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContactLabel>>(responseModel);
        }

        /// <summary>
        /// Return custom labels for a corporation’s contacts.
        /// <para>GET /corporations/{corporation_id}/contacts/labels/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of corporation contact labels.</returns>
        public async Task<ESIModelDTO<List<ContactLabel>>> GetCorporationContactLabelsV1Async(AuthDTO auth, int corporationId)
        {
            CheckAuth(auth, Scopes.ESI_CORPORATIONS_READ_CONTACTS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/contacts/labels/", auth);

            CheckResponse(nameof(GetCorporationContactLabelsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContactLabel>>(responseModel);
        }
    }
}
