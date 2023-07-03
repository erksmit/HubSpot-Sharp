
using HubSpot_Sharp.Authentication;

using Microsoft.Extensions.Configuration;

[assembly: Parallelize(Scope = ExecutionScope.ClassLevel)]

namespace Tests
{

    using HubSpot_Sharp.Authentication;

    using Microsoft.Extensions.Configuration;

    [TestClass]
    internal class Config
    {
        public static HubSpotApi Api { get; private set; }
        
        public static string? PrivateAccessToken { get; private set; }

        public static string? ClientId { get; private set; }
        public static string? ClientSecret { get; private set; }
        public static string? RedirectUri { get; private set; }
        public static string? RefreshToken { get; private set; }

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

            var token = new HubSpotToken
            {
                AccessToken = PrivateAccessToken
            };
            var client = new HubSpotClient(token);
            Api = new HubSpotApi(client);
        }
    }
}
