// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotException.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Net;

using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp
{
    /// <summary>
    /// Represents an error that occurred during a request to the HubSpot API.
    /// </summary>
    public class HubSpotException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubSpotException"/> class.
        /// </summary>
        /// <param name="response">
        /// The response of the faulty request.
        /// </param>
        public HubSpotException(HttpResponseMessage response)
            : base(response.ReasonPhrase)
        {
            string contents = response.Content.ReadAsStringAsync().Result;
            Contents = Serializer.DeserializeJson<HubSpotExceptionBody>(contents);
            StatusCode = response.StatusCode;
            RawJsonResponse = contents;
            Request = response.RequestMessage;
        }

        /// <summary>
        /// Gets the status code of the request.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the raw json response that was returned.
        /// </summary>
        public string RawJsonResponse { get; }

        /// <summary>
        /// Gets the request that resulted in this error.
        /// </summary>
        public HttpRequestMessage? Request { get; }

        /// <summary>
        /// Gets the information contained in the body of the response.
        /// </summary>
        public HubSpotExceptionBody Contents { get; }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        private static HubSpotSerializer Serializer { get; } = new ();
    }
}