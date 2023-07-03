// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortingDirection.cs" company="">
//   
// </copyright>
// <summary>
//   The sorting direction.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// The sorting direction for a search result.
    /// </summary>
    [DataContract]
    public enum SortingDirection
    {
        /// <summary>
        /// Sort ascending.
        /// </summary>
        [EnumMember(Value = "ASCENDING")]
        Ascending,

        /// <summary>
        /// Sort descending.
        /// </summary>
        [EnumMember(Value = "DESCENDING")]
        Descending
    }
}