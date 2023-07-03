// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticationApi.cs" company="">
//   
// </copyright>
// <summary>
//   The authentication api used for Oauth authentication and other authentication related endpoints.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The authentication api used for OAuth authentication and other authentication related endpoints.
    /// </summary>
    public class AuthenticationApi
    {
        /// <summary>
        /// The client used to execute requests.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApi"/> class.
        /// </summary>
        /// <param name="hubSpotClient">
        /// The hub spot client used to execute requests.
        /// </param>
        public AuthenticationApi(HubSpotClient hubSpotClient)
        {
            client = hubSpotClient;
        }

        /// <summary>
        /// Gets information about the private access token of an app.
        /// </summary>
        /// <param name="token">
        /// The token to get information about.
        /// </param>
        /// <returns>
        /// A <see cref="PrivateTokenInformation"/> containing information about the private app.
        /// </returns>
        public PrivateTokenInformation GetPrivateTokenInformation(PrivateTokenInfoOptions token)
        {
            const string Path = "/oauth/v2/private-apps/get/access-token-info";
            var options = new RequestOptions(Path, HttpMethod.Post, entity: token, tokenLess: true);
            return client.Execute<PrivateTokenInformation>(options);
        }
        /// <inheritdoc cref="GetPrivateTokenInformation(PrivateTokenInfoOptions)"/>
        public PrivateTokenInformation GetPrivateTokenInformation(string token)
        {
            return GetPrivateTokenInformation(new PrivateTokenInfoOptions(token));
        }

        /// <summary>
        /// Gets infromation about an access token of an app
        /// </summary>
        /// <param name="accessToken">The token to get information on.</param>
        /// <returns>A <see cref="OAuthTokenInformation"/> containing information about the token.</returns>
        public OAuthTokenInformation GetAccessTokenInformation(string accessToken)
        {
            var path = $"/oauth/v1/access-tokens/{accessToken}";
            var options = new RequestOptions(path, tokenLess: true);
            return client.Execute<OAuthTokenInformation>(options);
        }

        /// <summary>
        /// Gets infromation about a refresh token of an app
        /// </summary>
        /// <param name="accessToken">The token to get information on.</param>
        /// <returns>A <see cref="OAuthTokenInformation"/> containing information about the token.</returns>
        public OAuthTokenInformation GetRefreshTokenInformation(string refreshToken)
        {
            var path = $"/oauth/v1/refresh-tokens/{refreshToken}";
            var options = new RequestOptions(path, tokenLess: true);
            return client.Execute<OAuthTokenInformation>(options);
        }

        /// <summary>
        /// Exchanges an Authorization token for a refresh token or Exchanges a refresh token for a access token
        /// </summary>
        /// <param name="data">
        /// The Grant data used to make the request
        /// </param>
        /// <returns>
        /// A <see cref="TokenExchangeResponse"/> containing the acquired tokens.
        /// </returns>
        public TokenExchangeResponse ExchangeTokens(GrantRequestOptions data)
        {
            const string Path = "/oauth/v1/token";
            var options = new RequestOptions(Path, HttpMethod.Post, formContent: data, tokenLess: true);
            return client.Execute<TokenExchangeResponse>(options);
        }

        /// <summary>
        /// Deletes a refresh token
        /// </summary>
        /// <param name="token">
        /// The token to delete.
        /// </param>
        public void DeleteRefreshToken(string token)
        {
            var path = $"/oauth/v1/refresh-tokens/{token}";
            client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// Gets the OAuth url that can be used to authorize an OAuth app, this function does not make any calls itself.
        /// </summary>
        /// <param name="clientId">
        /// The client id of the app.
        /// </param>
        /// <param name="redirectUrl">
        /// The url to redirect to after the authorization has completed. note: this must be a https adress or localhost
        /// </param>
        /// <param name="scopes">
        /// The permission scopes to request access to.
        /// </param>
        /// <param name="optionalScopes">
        /// Optional scopes to request access to, they don't need to be granted.
        /// </param>
        /// <returns>
        /// A url that can be used to authorize the app, after authorization a Get request is sent to the redirect url with the
        /// authorization token as a url parameter.
        /// </returns>
        public string GetOauthUrl(
            string clientId,
            string redirectUrl,
            IList<string> scopes,
            IList<string>? optionalScopes = null)
        {
            const string BaseUrl = "https://app.hubspot.com/oauth/authorize";

            var queryParams = new List<(string name, string value)>
            {
                ("redirect_uri", redirectUrl),
                ("scope", string.Join(" ", scopes)),
                ("client_id", clientId)
            };
            if (optionalScopes != null)
            {
                var scopeString = string.Join(" ", optionalScopes);
                queryParams.Add(("optional_scope", scopeString));
            }

            return BaseUrl + "?" + string.Join(
                       "&",
                       queryParams.Where(p => !string.IsNullOrEmpty(p.value)).Select(p => $"{p.name}={p.value}"));
        }
    }
}