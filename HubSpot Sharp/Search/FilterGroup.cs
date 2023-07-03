// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterGroup.cs" company="">
//   
// </copyright>
// <summary>
//   The filter group.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// A group of search filters
    /// </summary>
    [DataContract]
    public class FilterGroup
    {
        /// <summary>
        /// Gets or sets the filters of the group.
        /// </summary>
        public IList<Filter> Filters { get; set; }
    }
}