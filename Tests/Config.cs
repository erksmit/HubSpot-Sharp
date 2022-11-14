namespace Tests
{
    using HubSpot_Sharp.Authentication;

    using Microsoft.Extensions.Configuration;

    [TestClass]
    internal class Config
    {
        public static HubSpotClient Client { get; private set; }
        public static HubSpotApi Api { get; private set; }
        
        public static string PrivateAccessToken { get; private set; }

        [AssemblyInitialize]
        public static void SetupTests(TestContext context)
        {
            var config = new ConfigurationManager();
            config.AddJsonFile("appSettings.json");
            PrivateAccessToken = config.GetValue<string>("privateAccessToken") ?? throw new NullReferenceException("No private access token was provided.");
            var token = new HubSpotToken
            {
                AccessToken = PrivateAccessToken
            };
            Client = new HubSpotClient(token);
            Api = new HubSpotApi(Client);
        }
    }
}
