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
        where T : new()
    {
        /// <summary>
        /// Gets or sets the status indicating whether the operation was completed or is still pending.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the results of the request.
        /// </summary>
        public IList<T> Results { get; set; }
    }
}