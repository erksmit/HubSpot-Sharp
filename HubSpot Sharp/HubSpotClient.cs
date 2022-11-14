namespace HubSpot_Sharp
{
    using System.Security.Cryptography;
    using System.Threading;

    using HubSpot_Sharp.Authentication;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Serialization;

    using RestSharp;

    public class HubSpotClient
    {
        public static string BaseUrl => "https://api.hubapi.com";

        public HubSpotToken Token { get; set; }

        private readonly RestClient restClient;

        private readonly HubSpotSerializer serializer;


        public HubSpotClient(HubSpotToken token)
        {
            Token = token;
            restClient = new RestClient(BaseUrl);
            serializer = new HubSpotSerializer();
        }

        private string? SendRequest(RequestOptions options)
        {
            var request = new RestRequest(options.GetFullPath(), options.Method);
            if (!options.TokenLess)
            {
                request.AddHeader("authorization", "Bearer " + Token.AccessToken);
            }

            if (options.Entity != null)
            {
                request.AddParameter("application/json", serializer.Serialize(options.Entity), ParameterType.RequestBody);
            }

            RestResponse response = restClient.Execute(request);

            string? responseData = response.Content;

            if (!response.IsSuccessful)
            {
                if ((int)response.StatusCode != 429)
                {
                    throw new HubSpotException(response, request);
                }

                switch (options.RateLimit)
                {
                    case RateLimitOptions.Error:
                        {
                            throw new HubSpotException(response, request);
                        }
                    case RateLimitOptions.RetrySearch:
                        {
                            // HubSpot does not say how long until the rateLimit resets, so we must wait a full second
                            Thread.Sleep(1000);
                            // try again, but error if it times out again
                            options.RateLimit = RateLimitOptions.Error;
                            return SendRequest(options);
                        }
                    case RateLimitOptions.RetryRolling:
                        {
                            // TODO: count requests to ensure this is not hit in the first place
                            Thread.Sleep(10000);
                            options.RateLimit = RateLimitOptions.Error;
                            return SendRequest(options);
                        }
                    default:
                        throw new NotImplementedException();
                }
            }

            return responseData;
        }

        public void Execute(RequestOptions options)
        {
            SendRequest(options);
        }

        public void Execute(string path, Method method = Method.Get, object? entity = null)
        {
            var options = new RequestOptions(path, method, entity);
            Execute(options);
        }

        public T Execute<T>(RequestOptions options)
        {
            var json = SendRequest(options);
            return serializer.Deserialize<T>(json!);
        }

        public T Execute<T>(string path, Method method = Method.Get, object? entity = null)
        {
            var options = new RequestOptions(path, method, entity);
            return Execute<T>(options);
        }
    }
}