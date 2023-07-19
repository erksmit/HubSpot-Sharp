// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Deal.cs" company="">
//   
// </copyright>
// <summary>
//   The deal.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Deal
{
    /// <summary>
    /// The deal.
    /// </summary>
    [AssociationId("DEAL")]
    [ApiPathName("deals")]
    [DataContract]
    public class Deal : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [DataMember]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the close date.
        /// </summary>
        [DataMember]
        public DateTime CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the stage.
        /// </summary>
        [DataMember]
        public string Stage { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// </summary>
        [DataMember]
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the pipe line.
        /// </summary>
        [DataMember]
        public string PipeLine { get; set; }
    }
}