// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="">
//   
// </copyright>
// <summary>
//   The config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Authentication;

using Microsoft.Extensions.Configuration;

namespace Tests
{
    /// <summary>
    /// The config.
    /// </summary>
    [TestClass]
    public class Config
    {
        /// <summary>
        /// Gets the api.
        /// </summary>
        public static HubSpotApi Api { get; private set; }

        /// <summary>
        /// Gets the private access token.
        /// </summary>
        public static string? PrivateAccessToken { get; private set; }

        /// <summary>
        /// Gets the client id.
        /// </summary>
        public static string? ClientId { get; private set; }

        /// <summary>
        /// Gets the client secret.
        /// </summary>
        public static string? ClientSecret { get; private set; }

        /// <summary>
        /// Gets the redirect uri.
        /// </summary>
        public static string? RedirectUri { get; private set; }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        public static string? RefreshToken { get; private set; }

        /// <summary>
        /// Gets the auth method.
        /// </summary>
        public static string? AuthMethod { get; private set; }

        /// <summary>
        /// The setup tests.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
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
                    AccessToken = PrivateAccessToken ?? throw new Exception(
                                      "Private access token authorization is configured but no pat is specified."),
                    Mode = HubSpotAuthenticationMode.PrivateAccessToken
                },
                "oauth" => new HubSpotToken
                {
                    RefreshToken = RefreshToken ?? throw new Exception(
                                       "OAuth authorization is configured but no refresh token is specified."),
                    Mode = HubSpotAuthenticationMode.OAuth
                },
                "none" => new HubSpotToken
                {
                    AccessToken = string.Empty
                },
                _ => throw new ArgumentOutOfRangeException(nameof(token), "Unknown authentication mode configuration")
            };

            Api = new HubSpotApi(token);

            if (AuthMethod == "oauth")
            {
                var response = Api.Authentication.ExchangeTokens(
                        new GrantRequestOptions
                        {
                            ClientId = ClientId ?? throw new Exception(
                                           "OAuth authorization is configured but no ClientId is configured"),
                            ClientSecret = ClientSecret ?? throw new Exception(
                                               "OAuth authorization is configured but no client secret is configured"),
                            RedirectUri = RedirectUri ?? throw new Exception(
                                              "OAuth authorization is configured but no redirect uri is configured"),
                            RefreshToken = RefreshToken ?? throw new Exception(
                                               "OAuth authorization is configured but no refresh token is configured"),
                            GrantType = GrantType.RefreshToken
                        })
                    .GetAwaiter()
                    .GetResult();
                token.AccessToken = response.AccessToken;
            }
        }
    }
}