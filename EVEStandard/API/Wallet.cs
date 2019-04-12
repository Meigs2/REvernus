using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Wallet API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Wallet : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Wallet>();

        internal Wallet(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Returns a character’s wallet balance.
        /// <para>GET /characters/{character_id}/wallet/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet balance.</returns>
        public async Task<ESIModelDTO<double>> GetCharacterWalletBalanceV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/wallet/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterWalletBalanceV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<double>(responseModel);
        }

        /// <summary>
        /// Retrieve the given character’s wallet journal going 30 days back.
        /// <para>GET /characters/{character_id}/wallet/journal/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing journal entries.</returns>
        public async Task<ESIModelDTO<List<CharacterWalletJournal>>> GetCharacterWalletJournalV4Async(AuthDTO auth, int page, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v4/characters/{auth.CharacterId}/wallet/journal/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterWalletJournalV4Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterWalletJournal>>(responseModel);
        }

        /// <summary>
        /// Get wallet transactions of a character.
        /// <para>GET /characters/{character_id}/wallet/transactions/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fromId">Only show transactions happened before the one referenced by this id.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet transactions.</returns>
        public async Task<ESIModelDTO<List<WalletTransaction>>> GetCharacterWalletTransactionsV1Async(AuthDTO auth, long fromId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/wallet/transactions/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterWalletTransactionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<WalletTransaction>>(responseModel);
        }

        /// <summary>
        /// Get a corporation’s wallets.
        /// <para>GET /corporations/{corporation_id}/wallets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of corporation wallets.</returns>
        public async Task<ESIModelDTO<List<CorporationWallet>>> ReturnCorporationWalletBalanceV1Async(AuthDTO auth, int corpId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corpId}/wallets/", auth, ifNoneMatch);

            CheckResponse(nameof(ReturnCorporationWalletBalanceV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationWallet>>(responseModel);
        }

        /// <summary>
        /// Retrieve the given corporation’s wallet journal for the given division going 30 days back.
        /// <para>GET /corporations/{corporation_id}/wallets/{division}/journal/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="division">Wallet key of the division to fetch journals from.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing journal entries.</returns>
        public async Task<ESIModelDTO<List<CorporationWalletJournal>>> GetCorporationWalletJournalV3Async(AuthDTO auth, int corpId, int division, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v3/corporations/{corpId}/wallets/{division}/journal/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationWalletJournalV3Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationWalletJournal>>(responseModel);
        }

        /// <summary>
        /// Get wallet transactions of a corporation.
        /// <para>GET /corporations/{corporation_id}/wallets/{division}/transactions/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="division">Wallet key of the division to fetch journals from.</param>
        /// <param name="fromId">Only show transactions happened before the one referenced by this id.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet transactions.</returns>
        public async Task<ESIModelDTO<List<WalletTransaction>>> GetCorporationWalletTransactionsV1Async(AuthDTO auth, int corpId, int division, long fromId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corpId}/wallets/{division}/transactions/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationWalletTransactionsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<WalletTransaction>>(responseModel);
        }
    }
}
