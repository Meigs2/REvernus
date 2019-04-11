using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EVEStandard.Enumerations;
using EVEStandard.Models.SSO;
using Newtonsoft.Json;

namespace EVEStandard
{
    /// <summary>
    /// The SSO specifies the workflow required to use Single Sign-On with EVE Online. SSO can be used purely 
    /// for authentication or also for accessing ESI API endpoints that require specific scopes.
    /// </summary>
    /// <remarks>
    /// For information on how to utilize the SSO class please refer to the README on our GitHub.
    /// <see>
    ///     <cref>https://github.com/gehnster/EVEStandard</cref>
    /// </see>
    /// </remarks>
    public class SSO
    {
        private static HttpClient http;

        private const string TRANQUILITY_SSO_BASE_URL = "https://login.eveonline.com";
        private const string SINGULARITY_SSO_BASE_URL = "https://sisilogin.testeveonline.com";
        private const string SSO_AUTHORIZE = "/oauth/authorize/?";
        private const string SSO_TOKEN = "/oauth/token";
        private const string SSO_VERIFY = "/oauth/verify";
        private const string SSO_REVOKE = "/oauth/revoke";

        private readonly DataSource dataSource;

        /// <summary>
        /// Constructor for SSO class.
        /// </summary>
        /// <param name="callbackUri">The Callback URL that you provided in your ESI application. If this doesn't match with what ESI has then SSO auth will fail.</param>
        /// <param name="clientId">The Client Id you were assigned in your ESI application.</param>
        /// <param name="secretKey">The Secret Key you were assigned in your ESI application, this should NEVER be human-readable in your application.</param>
        /// <param name="dataSource"></param>
        /// <exception cref="EVEStandardException" >Called when any of the parameters is null or empty.</exception>
        /// <remarks>
        /// Except for public data within ESI, you need an application to gain access behind SSO. You can create an application at <see>
        ///         <cref>https://developers.eveonline.com/</cref>
        ///     </see>
        ///     You will probably want to create at least two applications, one for local development and one for production since the <paramref name="callbackUri"/> requires to match in the callback.
        /// </remarks>
        internal SSO(string callbackUri, string clientId, string secretKey, DataSource dataSource)
        {
            if(string.IsNullOrEmpty(callbackUri) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(secretKey))
            {
                throw new EVEStandardException("SSO should be initialized with non-null and non-empty strings. callbackUri: " + callbackUri + " clientId: " + clientId + " secretKey: " + secretKey);
            }

            CallbackUri = callbackUri;
            ClientId = clientId;
            SecretKey = secretKey;
            this.dataSource = dataSource;
        }

        internal static HttpClient HTTP {
            set => http = value;
        }

        internal string CallbackUri { get; }

        internal string ClientId { get; }

        internal string SecretKey { get; }

        /// <summary>
        /// Generates the URL you should have users click on with one of the EVE Online provided button images.
        /// A state parameter in the URL is optional, but expected for security so this function creates one based on a Base64 encoded Guid.
        /// </summary>
        /// <param name="scopes">List of the required scopes for your application</param>
        /// <returns>The <c>Authorization</c> POCO with the SignInURI parameter set and the ExpectedState parameter set.</returns>
        /// <exception cref="EVEStandardException" ><paramref name="scopes"/> parameter was empty or null</exception>
        public Authorization AuthorizeToEVEUri(List<string> scopes)
        {
            return AuthorizeToEVEUri(scopes, Guid.NewGuid().ToString());
        }

        /// <summary>
        /// Generates the URL you should have users click on with one of the EVE Online provided button images.
        /// A state parameter in the URL is optional, but expected for security.
        /// </summary>
        /// <param name="scopes">List of the required scopes for your application</param>
        /// <param name="state">State is used to verify that the callback is coming from where you expect it to come from.</param>
        /// <returns>The <c>Authorization</c> POCO with the SignInURI parameter set and the ExpectedState parameter set.</returns>
        /// <exception cref="EVEStandardException" ><paramref name="scopes"/> parameter was empty or null</exception>
        public Authorization AuthorizeToEVEUri(List<string> scopes, string state)
        {
            if (scopes == null)
            {
                throw new ArgumentNullException();
            }

            var model = new Authorization
            {
                ExpectedState = state ?? ""
            };

            model.SignInURI = GetBaseURL() + SSO_AUTHORIZE + "response_type=code&redirect_uri=" + HttpUtility.UrlEncode(CallbackUri) +
                "&client_id=" + ClientId + "&scope=" + HttpUtility.UrlEncode(String.Join(" ", scopes)) + "&state=" + HttpUtility.UrlEncode(model.ExpectedState);

            return model;
        }

        /// <summary>
        /// Once your application receives the callback from SSO, you call this to verify the state is the expected one to be returned and to request an access code with the authenication code you were given.
        /// </summary>
        /// <param name="model">The <c>Authorization</c> POCO with at least, ExpectedState, ReturnedState, and AuthorizationCode properties set.</param>
        /// <returns><c>AccessTokenDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<AccessTokenDetails> VerifyAuthorizationAsync(Authorization model)
        {
            if (model.ReturnedState == null)
            {
                model.ReturnedState = "";
            }

            if (model.ExpectedState == null)
            {
                model.ExpectedState = "";
            }

            if(model.ExpectedState != model.ReturnedState)
            {
                throw new EVEStandardException("model parameter expected the ExpectedState to match the ReturnedState, they are actually set as: ExpectedState: " + model.ExpectedState + " ReturnedState: " + model.ReturnedState);
            }

            try
            {
                var byteArray = Encoding.ASCII.GetBytes(ClientId + ":" + SecretKey);

                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", model.AuthorizationCode)
                });
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_TOKEN),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await http.SendAsync(request).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<AccessTokenDetails>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        /// <summary>
        /// If your access token has expired and you need a new one you can pass the <c>AccessTokenDetails</c> POCO here, with a valid refresh token, to retrieve a new access token.
        /// </summary>
        /// <param name="refreshToken">The refresh token you want to use to get a new access token.</param>
        /// <returns><c>AccessTokenDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<AccessTokenDetails> GetRefreshTokenAsync(string refreshToken)
        {
            try
            {
                var byteArray = Encoding.ASCII.GetBytes(ClientId + ":" + SecretKey);
                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken)
                });
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_TOKEN),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await http.SendAsync(request).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<AccessTokenDetails>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        /// <summary>
        /// Retrieve basic details about the Character you were given access to during the SSO process.
        /// </summary>
        /// <param name="accessToken">The access token used to retrieve character details.</param>
        /// <returns><c>CharacterDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<CharacterDetails> GetCharacterDetailsAsync(string accessToken)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_VERIFY),
                    Method = HttpMethod.Get
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var verifyResponse = await http.SendAsync(request).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<CharacterDetails>(await verifyResponse.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        /// <summary>
        /// Revokes either the access token or the refresh token a user gave access to.
        /// </summary>
        /// <param name="type">Was it an access or refresh token you are trying to revoke?</param>
        /// <param name="token">The token you are trying to revoke.</param>
        /// <returns>True if the token was revoked.</returns>
        public async Task<bool> RevokeTokenAsync(RevokeType type, string token)
        {
            try
            {
                var byteArray = Encoding.ASCII.GetBytes(ClientId + ":" + SecretKey);
                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("token_type_hint", type == RevokeType.ACCESS_TOKEN ? "access_token" : "refresh_token"),
                    new KeyValuePair<string, string>("token", token)
                });
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_REVOKE),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await http.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        // ReSharper disable once InconsistentNaming
        private string GetBaseURL()
        {
            return dataSource == DataSource.Singularity ? SINGULARITY_SSO_BASE_URL : TRANQUILITY_SSO_BASE_URL;
        }
    }
}
