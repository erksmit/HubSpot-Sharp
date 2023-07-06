// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListResult.cs" company="">
//   
// </copyright>
// <summary>
//   The list result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using HubSpot_Sharp.Search;

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// A List of results from List requests.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the results.
    /// </typeparam>
    [DataContract]
    public class ListResult<T>
    {
        public ListResult(IList<T> results, PagingModel paging)
        {
            Results = results;
            Paging = paging;
        }

        /// <summary>
        /// Gets the List of results.
        /// </summary>
        [DataMember]
        public IList<T> Results { get; }

        /// <summary>
        /// Gets the paging object if there are more results available.
        /// </summary>
        [DataMember]
        public PagingModel Paging { get; }
    }

    public static class ListResultExtensions
    {
        public static IList<T> GetResults<T>(this ListResult<PropertyBag<T>> result) where T : HubSpotObject
        {
            return result.Results.UnpackMany();
        }
    }
}