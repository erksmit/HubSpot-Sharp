// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequestOptions.cs" company="">
//   
// </copyright>
// <summary>
//   The request options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Options
{
    /// <summary>
    /// The request options.
    /// </summary>
    [DataContract]
    public class RequestOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions" /> class.
        /// </summary>
        public RequestOptions()
        {
            EndPointPath = string.Empty;
            Method = HttpMethod.Get;
            RateLimit = RateLimitOptions.RetryRolling;
            QueryParams = new List<(string name, string value)>();
            TokenLess = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestOptions"/> class using the provided arguments.
        /// </summary>
        /// <param name="endPointPath">
        /// the end point path to make the request to.
        /// </param>
        /// <param name="method">
        /// The method of the request.
        /// </param>
        /// <param name="entity">
        /// The entity that makes up the request's body.
        /// </param>
        /// <param name="rateLimit">
        /// specifies what to do when a rateLimit is hit.
        /// </param>
        /// <param name="tokenLess">
        /// Indicates whether to use the client's token in the request
        /// </param>
        /// <param name="queryParams">
        /// The query params to include in the request.
        /// </param>
        public RequestOptions(
            string endPointPath,
            HttpMethod? method = null,
            object? entity = null,
            object? formContent = null,
            RateLimitOptions rateLimit = RateLimitOptions.RetryRolling,
            bool tokenLess = false,
            params (string name, string value)[] queryParams)
        {
            EndPointPath = endPointPath;
            method ??= HttpMethod.Get;
            Method = method;
            RateLimit = rateLimit;
            Entity = entity;
            FormContent = formContent;
            QueryParams = queryParams.ToList();
            TokenLess = tokenLess;
        }

        /// <summary>
        /// Gets or sets the end point path to make the request to.
        /// </summary>
        public string EndPointPath { get; set; }

        /// <summary>
        /// Gets or sets the method of the request.
        /// </summary>
        public HttpMethod Method { get; set; }

        /// <summary>
        /// Gets or sets what to do when a rateLimit is hit.
        /// </summary>
        public RateLimitOptions RateLimit { get; set; }

        /// <summary>
        /// Gets or sets the query params for the request.
        /// </summary>
        public IList<(string name, string value)> QueryParams { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use the client's token in the request
        /// </summary>
        public bool TokenLess { get; set; }

        /// <summary>
        /// Gets or sets the entity that makes up the request's body.
        /// </summary>
        public object? Entity { get; set; }

        /// <summary>
        /// Gets or sets the form content header.
        /// </summary>
        public object? FormContent { get; set; }

        /// <summary>
        /// Adds a query parameter to the request
        /// </summary>
        /// <param name="name">
        /// The name of the parameter.
        /// </param>
        /// <param name="value">
        /// The value of the parameter.
        /// </param>
        public void AddParam(string name, object value)
        {
            QueryParams.Add((name, value.ToString()!));
        }

        /// <summary>
        /// Gets the full url path of the request including query parameters
        /// </summary>
        /// <returns>
        /// The full url of the request.
        /// </returns>
        public string GetFullPath()
        {
            if (QueryParams.Count > 0)
            {
                return EndPointPath + "?" + string.Join(
                           "&",
                           QueryParams.Where(p => !string.IsNullOrEmpty(p.value)).Select(p => $"{p.name}={p.value}"));
            }

            return EndPointPath;
        }
    }
}