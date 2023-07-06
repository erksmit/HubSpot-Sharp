// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BatchResult.cs" company="">
//   
// </copyright>
// <summary>
//   The batch result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// The result for a batch request
    /// </summary>
    /// <typeparam name="T">
    /// The object type contained withing the batch result
    /// </typeparam>
    public class BatchResult<T>
    {
        public BatchResult(string status, IList<T> results)
        {
            Status = status;
            Results = results;
        }

        /// <summary>
        /// Gets the status indicating whether the operation was completed or is still pending.
        /// </summary>
        public string Status { get; }

        /// <summary>
        /// Gets the results of the request.
        /// </summary>
        public IList<T> Results { get; }
    }

    public static class BatchResultExtensions
    {
        public static IList<T> GetResults<T>(this BatchResult<PropertyBag<T>> result) where T : HubSpotObject
        {
            return result.Results.UnpackMany();
        }
    }
}