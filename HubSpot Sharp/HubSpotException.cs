namespace HubSpot_Sharp
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    using RestSharp;

    public class HubSpotException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public string RawJsonResponse { get; private set; }

        /// <summary>
        /// The request that resulted in this error
        /// </summary>
        public RestRequest? Request { get; private set; }

        public HubSpotExceptionBody Contents { get; private set; }

        public HubSpotException(RestResponseBase response, RestRequest? request = null) : base(response.StatusDescription)
        {
            Contents = JsonConvert.DeserializeObject<HubSpotExceptionBody>(response.Content!, SerializerSettings)!;
            this.StatusCode = response.StatusCode;
            RawJsonResponse = response.Content!;
            Request = request;
        }

        private static JsonSerializerSettings SerializerSettings { get; } = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                },
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}