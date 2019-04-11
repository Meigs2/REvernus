using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Contracts API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Contracts : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Contracts>();

        internal Contracts(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Returns contracts available to a character, only if the character is issuer, acceptor or assignee. 
        /// Only returns contracts no older than 30 days, or if the status is "in_progress".
        /// <para>GET /characters/{character_id}/contracts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contracts.</returns>
        public async Task<ESIModelDTO<List<Contract>>> GetContractsV1Async(AuthDTO auth, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CONTRACTS_READ_CHARACTER_CONTRACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/contracts/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetContractsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Contract>>(responseModel);
        }

        /// <summary>
        /// Lists items of a particular contract.
        /// <para>GET /characters/{character_id}/contracts/{contract_id}/items/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of items in this contract.</returns>
        public async Task<ESIModelDTO<List<ContractItem>>> GetContractItemsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CONTRACTS_READ_CHARACTER_CONTRACTS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/contracts/{contractId}/items/", auth, ifNoneMatch);

            CheckResponse(nameof(GetContractItemsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContractItem>>(responseModel);
        }

        /// <summary>
        /// Lists bids on a particular auction contract.
        /// <para>GET /characters/{character_id}/contracts/{contract_id}/bids/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bids.</returns>
        public async Task<ESIModelDTO<List<ContractBid>>> GetContractBidsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CONTRACTS_READ_CHARACTER_CONTRACTS_1);

            var responseModel = await GetAsync($"/v1/characters/{auth.CharacterId}/contracts/{contractId}/bids/", auth, ifNoneMatch);

            CheckResponse(nameof(GetContractBidsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContractBid>>(responseModel);
        }

        /// <summary>
        /// Returns a paginated list of all public contracts in the given region.
        /// <para>GET /v1/contracts/public/{region_id}/</para>
        /// </summary>
        /// <param name="regionId">An EVE region id.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contracts.</returns>
        public async Task<ESIModelDTO<List<Contract>>> GetPublicContractsV1Async(int regionId, int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/contracts/public/{regionId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetPublicContractsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Contract>>(responseModel);
        }

        /// <summary>
        /// Lists bids on a public auction contract.
        /// <para>GET /v1/contracts/public/bids/{contract_id}/</para>
        /// </summary>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bids.</returns>
        public async Task<ESIModelDTO<List<ContractBid>>> GetPublicContractBidsV1Async(int contractId, int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/contracts/public/bids/{contractId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetPublicContractBidsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContractBid>>(responseModel);
        }

        /// <summary>
        /// Lists items of a public contract.
        /// </summary>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of items in this contract.</returns>
        public async Task<ESIModelDTO<List<ContractItem>>> GetPublicContractItemsV1Async(int contractId, int page = 1, string ifNoneMatch = null)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/contracts/public/items/{contractId}/", ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetPublicContractItemsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContractItem>>(responseModel);
        }

        /// <summary>
        /// Returns contracts available to a corporation, only if the corporation is issuer, acceptor or assignee. 
        /// Only returns contracts no older than 30 days, or if the status is "in_progress".
        /// <para>GET /corporations/{corporation_id}/contracts/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corporationId">An EVE corporation ID</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of contracts.</returns>
        public async Task<ESIModelDTO<List<Contract>>> GetCorporationContractsV1Async(AuthDTO auth, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CONTRACTS_READ_CORPORATION_CONTRACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/contracts/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationContractsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<Contract>>(responseModel);
        }

        /// <summary>
        /// Lists items of a particular contract.
        /// <para>GET /corporations/{corporation_id}/contracts/{contract_id}/items/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="corporationId">An EVE corporation ID</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of items in this contract.</returns>
        public async Task<ESIModelDTO<List<ContractItem>>> GetCorporationContractItemsV1Async(AuthDTO auth, int contractId, int corporationId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CONTRACTS_READ_CORPORATION_CONTRACTS_1);

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/contracts/{contractId}/items/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationContractItemsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContractItem>>(responseModel);
        }

        /// <summary>
        /// Lists bids on a particular auction contract.
        /// <para>GET /corporations/{corporation_id}/contracts/{contract_id}/bids/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">ID of a contract.</param>
        /// <param name="corporationId">An EVE corporation ID</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing a list of bids.</returns>
        public async Task<ESIModelDTO<List<ContractBid>>> GetCorporationContractBidsV1Async(AuthDTO auth, int contractId, int corporationId, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_CONTRACTS_READ_CORPORATION_CONTRACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/v1/corporations/{corporationId}/contracts/{contractId}/bids/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCorporationContractBidsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<ContractBid>>(responseModel);
        }
    }
}
