namespace HubSpot_Sharp.Options
{
    /// <summary>
    /// Specifies what to do when a rateLimit is hit
    /// </summary>
    public enum RateLimitOptions
    {
        /// <summary>
        /// Throw an error when the rateLimit is hit
        /// </summary>
        Error,

        /// <summary>
        /// Retry the request after waiting 1 second, as required by search endpoints
        /// </summary>
        RetrySearch,

        /// <summary>
        /// Retry the request after 10 seconds
        /// </summary>
        RetryRolling
    }
}