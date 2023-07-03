// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Filter.cs" company="">
//   
// </copyright>
// <summary>
//   The filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// A filter in a search request
    /// </summary>
    [DataContract]
    public class Filter
    {
        /// <summary>
        /// Gets or sets the of the filter if the operators requires a value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the values of the filter if the operator requires multiple values.
        /// </summary>
        public IList<string> Values { get; set; }

        /// <summary>
        /// Gets or sets the name of the property to apply the filter to.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the operation the filter performs.
        /// </summary>
        public SearchOperator Operator { get; set; }
    }
}