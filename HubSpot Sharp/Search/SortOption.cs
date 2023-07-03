// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortOption.cs" company="">
//   
// </copyright>
// <summary>
//   The sort option.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// An option for sorting the results of a search request.
    /// </summary>
    [DataContract]
    public class SortOption
    {
        /// <summary>
        /// Gets or sets the property name that will be sorted.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the direction to sort in.
        /// </summary>
        public SortingDirection Direction { get; set; }
    }
}