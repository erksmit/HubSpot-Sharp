// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListResult.cs" company="">
//   
// </copyright>
// <summary>
//   The list result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Search;

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// A List of results from List requests.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the results.
    /// </typeparam>
    public class ListResult<T>
        where T : new()
    {
        /// <summary>
        /// Gets or sets the List of results.
        /// </summary>
        public IList<T> Results { get; set; }

        /// <summary>
        /// Gets or sets the paging object if there are more results available.
        /// </summary>
        public PagingModel Paging { get; set; }
    }
}