// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotClient.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot client.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

using HubSpot_Sharp.Authentication;
using HubSpot_Sharp.Options;
using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp
{
    /// <summary>
    /// The client used for making requests to the HubSpot api.
    /// </summary>
    public class HubSpotClient : IDisposable
    {
        /// <summary>
        /// The rest client used for making the requests.
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// The serializer used for serializing json.
        /// </summary>
        private readonly HubSpotSerializer serializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HubSpotClient"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public HubSpotClient(HubSpotToken token)
        {
            Token = token;
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
            serializer = new HubSpotSerializer();
        }

        /// <summary>
        /// The base url for the HubSpot api.
        /// </summary>
        public const string BaseUrl = @"https://api.hubapi.com";

        /// <summary>
        /// Gets or sets the token used for authentication.
        /// </summary>
        public HubSpotToken Token { get; set; }

        /// <summary>
        /// Sends a request to the hubSpot api and returns the response json.
        /// </summary>
        /// <param name="options">
        /// The options for the request.
        /// </param>
        /// <returns>
        /// The request body.
        /// </returns>
        private async Task<string> SendRequest(RequestOptions options)
        {
            var request = new HttpRequestMessage(options.Method, options.EndPointPath);
            if (options.TokenLess == false)
            {
                request.Headers.Add("authorization", "Bearer " + Token.AccessToken);
            }

            if (options.Entity != null)
            {
                string json = serializer.SerializeJson(options.Entity);
                request.Content = new StringContent(json, Encoding.UTF8, mediaType: MediaTypeNames.Application.Json);
            }

            if (options.FormContent != null)
            {
                string form = serializer.SerializeUrlEncoded(options.FormContent);
                request.Content = new StringContent(form, Encoding.UTF8, mediaType: "application/x-www-form-urlencoded");
            }
            
            var response = await client.SendAsync(request);

            string responseData = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode == false)
            {
                // statuscode 429 indicates a rateLimit error
                if ((int)response.StatusCode != 429)
                {
                    throw new HubSpotException(response);
                }

                switch (options.RateLimit)
                {
                    case RateLimitOptions.Error:
                    {
                        throw new HubSpotException(response);
                    }

                    case RateLimitOptions.RetrySearch:
                    {
                        // HubSpot does not say how long until the rateLimit resets, so we must wait a full second
                        Thread.Sleep(1000);

                        // try again, but error if it times out again
                        options.RateLimit = RateLimitOptions.Error;
                        return await SendRequest(options);
                    }

                    case RateLimitOptions.RetryRolling:
                    {
                        // the rolling ratelimit is generally not hit, but in the future it would be a good idea to ensure this ratelimit wont ever be hit
                        Thread.Sleep(10000);
                        options.RateLimit = RateLimitOptions.Error;
                        return await SendRequest(options);
                    }

                    default:
                        throw new NotImplementedException();
                }
            }

            return responseData;
        }

        /// <summary>
        /// Executes a request without a response
        /// </summary>
        /// <param name="options">
        /// The options for the request.
        /// </param>
        public async Task Execute(RequestOptions options)
        {
            await SendRequest(options);
        }

        /// <summary>
        /// Executes a request using the provided arguments.
        /// </summary>
        /// <param name="path">
        /// The full path to the endpoint.
        /// </param>
        /// <param name="method">
        /// The request method.
        /// </param>
        /// <param name="entity">
        /// The content of the request.
        /// </param>
        public async Task Execute(string path, HttpMethod? method = null, object? entity = null)
        {
            method ??= HttpMethod.Get;
            var options = new RequestOptions(path, method, entity);
            await Execute(options);
        }

        /// <summary>
        /// Executes a request using the provided arguments.
        /// </summary>
        /// <param name="options">
        /// The options for the request.
        /// </param>
        /// <typeparam name="T">
        /// The type object for the response json
        /// </typeparam>
        /// <returns>
        /// The response object
        /// </returns>
        public async Task<T> Execute<T>(RequestOptions options)
        {
            var json = await SendRequest(options);
            return serializer.DeserializeJson<T>(json);
        }

        /// <summary>
        /// Executes a request using the provided arguments.
        /// </summary>
        /// <param name="path">
        /// The full path to the endpoint.
        /// </param>
        /// <param name="method">
        /// The request method.
        /// </param>
        /// <param name="entity">
        /// The content of the request.
        /// </param>
        /// <typeparam name="T">
        /// The type object for the response json
        /// </typeparam>
        /// <returns>
        /// The response object
        /// </returns>
        public async Task<T> Execute<T>(string path, HttpMethod? method = null, object? entity = null)
        {
            method ??= HttpMethod.Get;
            var options = new RequestOptions(path, method, entity);
            return await Execute<T>(options);
        }

        void IDisposable.Dispose() => client.Dispose();
    }
}