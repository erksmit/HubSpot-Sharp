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
        public SearchResults(int total, IList<PropertyBag<T>> results, PagingModel? paging = null)
        {
            Total = total;
            Results = results;
            Paging = paging;
        }

        /// <summary>
        /// Gets the total amount of search results.
        /// </summary>
        [DataMember]
        public int Total { get; }

        /// <summary>
        /// Gets the results of the request.
        /// </summary>
        [DataMember]
        private IList<PropertyBag<T>> Results { get; }

        /// <summary>
        /// Gets the paging object for further pagination.
        /// </summary>
        [DataMember]
        public PagingModel? Paging { get; }

        /// <summary>
        /// Unpacks the results of the search request.
        /// </summary>
        /// <returns>
        /// The unpacked objects.
        /// </returns>
        public IList<T> GetResults() => PropertyBag<T>.UnpackMany(Results);
    }
}