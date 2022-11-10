namespace HubSpot_Sharp
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    using RestSharp;

    [DataContract]
    public class HubSpotException : Exception
    {
        [IgnoreDataMember]
        public HttpStatusCode ErrorCode { get; set; }

        [IgnoreDataMember]
        public string RawJsonResponse { get; set; }

        [IgnoreDataMember]
        public string Description { get; set; }

        /// <summary>
        /// The request that resulted in this error
        /// </summary>
        [IgnoreDataMember]
        public RestRequest? Request { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public new string Message { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "subCategory")]
        public string SubCategory { get; set; }

        public static HubSpotException FromResponse(RestResponse response, RestRequest? request = null)
        {
            var settings = new JsonSerializerSettings
                               {
                                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                                   Converters = new List<JsonConverter>
                                                    {
                                                        new StringEnumConverter()
                                                    },
                                   NullValueHandling = NullValueHandling.Ignore
                               };
            var exception = JsonConvert.DeserializeObject<HubSpotException>(response.Content!, settings)!;
            exception.ErrorCode = response.StatusCode;
            exception.Description = response.StatusDescription!;
            exception.RawJsonResponse = response.Content!;
            exception.Request = request;
            return exception;
        }
    }
}