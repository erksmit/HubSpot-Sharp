// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagingModel.cs" company="">
//   
// </copyright>
// <summary>
//   The paging model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Search
{
    /// <summary>
    /// The pagination model that contains the offset for further requests.
    /// </summary>
    [DataContract]
    public class PagingModel
    {
        /// <summary>
        /// Gets or sets the next model that has information about the next page.
        /// </summary>
        [DataMember]
        public PagingNextModel Next { get; set; }
    }
}