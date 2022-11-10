namespace HubSpot_Sharp
{
    using RestSharp;

    public class RequestOptions
    {
        public string EndPointPath { get; set; }
        public Method Method { get; set; }
        public RateLimitOptions RateLimit { get; set; }
        public IList<(string name, string value)> QueryParams { get; set; }
        public bool TokenLess { get; set; }
        public object? Entity { get; set; }

        public RequestOptions()
        {
            EndPointPath = string.Empty;
            Method = Method.Get;
            RateLimit = RateLimitOptions.RetryRolling;
            QueryParams = new List<(string name, string value)>();
            TokenLess = false;
        }

        public RequestOptions(string endPointPath, Method method = Method.Get, object? entity = null, RateLimitOptions rateLimit = RateLimitOptions.RetryRolling, bool tokenLess = false, params (string name, string value)[] queryParams)
        {  
            this.EndPointPath = endPointPath;
            Method = method;
            RateLimit = rateLimit;
            Entity = entity;
            QueryParams = queryParams.ToList();
            TokenLess = tokenLess;
        }

        public void AddParam(string name, object value)
        {
            QueryParams.Add((name, value.ToString()!));
        }

        public string GetFullPath()
        {
            if (QueryParams.Count > 0)
            {
                return this.EndPointPath + "?" + string.Join("&", QueryParams.Where(p => !string.IsNullOrEmpty(p.value)).Select(p => $"{p.name}={p.value}"));
            }

            return this.EndPointPath;
        }
    }
}
