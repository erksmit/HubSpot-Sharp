// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchOptions.cs" company="">
//   
// </copyright>
// <summary>
//   The search options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// The form for a search request.
    /// </summary>
    [DataContract]
    public class SearchOptions
    {
        /// <summary>
        /// Gets or sets the filter groups to filter the results.
        /// </summary>
        public IList<FilterGroup> FilterGroups { get; set; }

        /// <summary>
        /// Gets or sets the query to filter the results.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets object properties to return after the search.
        /// </summary>
        [DataMember(Name = "properties")]
        public IList<string> PropertiesToInclude { get; set; }

        /// <summary>
        /// Gets or sets the sorting options for the results. While this is a list, HubSpot only allows a single sorting rule to be used.
        /// </summary>
        public IList<SortOption> Sorts { get; set; }

        /// <summary>
        /// Gets or sets the amount of records to return.
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the offset for the search obtained through a paging object.
        /// </summary>
        public string After { get; set; }

        public SearchOptions() 
        {
            Limit = 100;
        }
    }
}