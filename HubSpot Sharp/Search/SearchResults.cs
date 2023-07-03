// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchResults.cs" company="">
//   
// </copyright>
// <summary>
//   The search results.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// The result of a search request.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the results
    /// </typeparam>
    [DataContract]
    public class SearchResults<T>
        where T : HubSpotObject, new()
    {
        /// <summary>
        /// Gets or sets the total amount of search results.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the paging object for further pagination.
        /// </summary>
        public PagingModel Paging { get; set; }

        /// <summary>
        /// Gets or sets the results of the request.
        /// </summary>
        public IList<PropertyBag<T>> Results { get; set; }

        /// <summary>
        /// Unpacks the results of the search request.
        /// </summary>
        /// <returns>
        /// The unpacked objects.
        /// </returns>
        public IList<T> UnpackResults() => PropertyBag<T>.UnpackMany(Results);
    }
}