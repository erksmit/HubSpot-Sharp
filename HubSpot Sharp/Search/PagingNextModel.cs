// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingNextModel.cs" company="">
//   
// </copyright>
// <summary>
//   The next model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// The next model used for pagination.
    /// </summary>
    [DataContract]
    public class PagingNextModel
    {
        /// <summary>
        /// Gets or sets the offset for the next page.
        /// </summary>
        [DataMember]
        public string After { get; set; }

        /// <summary>
        /// Gets or sets the link that can be used to request the next page, this is not used in the api.
        /// </summary>
        [DataMember]
        public string Link { get; set; }
    }
}