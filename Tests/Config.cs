namespace Tests
{

    using HubSpot_Sharp.Authentication;

    using Microsoft.Extensions.Configuration;

    [TestClass]
    public class Config
    {
        public static HubSpotApi Api { get; private set; }
        
        public static string? PrivateAccessToken { get; private set; }

        public static string? ClientId { get; private set; }
        public static string? ClientSecret { get; private set; }
        public static string? RedirectUri { get; private set; }
        public static string? RefreshToken { get; private set; }

        public static string? AuthMethod { get; private set; }

        [AssemblyInitialize]
        public static void SetupTests(TestContext context)
        {
            var config = new ConfigurationManager();
            config.AddJsonFile("appSettings.json");
            PrivateAccessToken = config.GetValue<string>("privateAccessToken");

            ClientId = config.GetValue<string>("clientId");
            ClientSecret = config.GetValue<string>("clientSecret");
            RedirectUri = config.GetValue<string>("redirectUri");
            RefreshToken = config.GetValue<string>("refreshToken");
            AuthMethod = config.GetValue<string>("authMethod");

            HubSpotToken token = AuthMethod switch
            {
                "private" => new HubSpotToken
                {
                    AccessToken = PrivateAccessToken ?? throw new Exception("Private access token authorization is configured but no pat is specified."),
                    Mode = HubSpotAuthenticationMode.PrivateAccessToken
                },
                "oauth" => new HubSpotToken
                {
                    RefreshToken = RefreshToken ?? throw new Exception("OAuth authorization is configured but no refresh token is specified."),
                    Mode = HubSpotAuthenticationMode.OAuth
                },
                "none" => new HubSpotToken
                {
                    AccessToken = ""
                },
                _ => throw new ArgumentOutOfRangeException("Unknown authentication mode configuration")
            };

            Api = new HubSpotApi(token);

            if (AuthMethod == "oauth")
            {
                var response =Api.Authentication.ExchangeTokens(
                    new GrantRequestOptions
                    {
                        ClientId = ClientId ?? throw new Exception("OAuth authorization is configured but no ClientId is configured"),
                        ClientSecret = ClientSecret ?? throw new Exception("OAuth authorization is configured but no client secret is configured"),
                        RedirectUri = RedirectUri ?? throw new Exception("OAuth authorization is configured but no redirect uri is configured"),
                        RefreshToken = RefreshToken ?? throw new Exception("OAuth authorization is configured but no refresh token is configured"),
                        GrantType = GrantType.RefreshToken
                    }).GetAwaiter().GetResult();
                token.AccessToken = response.AccessToken;
            }
        }
    }
}
