namespace HubSpot_Sharp.Authentication
{
    using System.Collections.Generic;
    using System.Linq;

    using HubSpot_Sharp;

    using RestSharp;

    public class AuthenticationApi
    {
        private readonly HubSpotClient client;

        public AuthenticationApi(HubSpotClient hubSpotClient)
        {
            client = hubSpotClient;
        }

        public TokenInformation GetInformation(HubSpotToken token)
        {
            const string Path = "/oauth/v2/private-apps/get/access-token-info";
            var options = new RequestOptions(Path, Method.Post, entity: token, tokenLess: true);
            return client.Execute<TokenInformation>(options);
        }

        public TokenExchangeResponse ExchangeTokens(GrantRequestForm data)
        {
            const string Path = "/oauth/v1/token";
            var options = new RequestOptions(Path, Method.Post, entity: data, tokenLess: true);
            return client.Execute<TokenExchangeResponse>(options);
        }

        public void DeleteRefreshToken(string token)
        {
            var path = $"/oauth/v1/refresh-tokens/{token}";
            var options = new RequestOptions(path, Method.Delete);
            client.Execute(options);
        }

        public static string GetOauthUrl(string clientId, string redirectUrl, IList<string> scopes, IList<string>? optionalScopes = null)
        {
            var queryParams = new List<(string name, string value)>
            {
                ("scope", string.Join(" ", scopes)),
                ("client_id", clientId)
            };
            if (optionalScopes != null)
            {
                var scopeString = string.Join(" ", optionalScopes);
                queryParams.Add(("optional_scope", scopeString));
            }

            return redirectUrl + "?" + string.Join("&", queryParams.Where(p => !string.IsNullOrEmpty(p.value)).Select(p => $"{p.name}={p.value}"));
        }
    }
}