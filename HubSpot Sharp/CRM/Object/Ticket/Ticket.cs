// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ticket.cs" company="">
//   
// </copyright>
// <summary>
//   The ticket.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Ticket
{
    /// <summary>
    /// The ticket.
    /// </summary>
    [DataContract]
    [AssociationId("TICKET")]
    [ApiPathName("tickets")]
    public class Ticket : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the pipeline.
        /// </summary>
        [DataMember(Name = "hs_pipeline")]
        public string Pipeline { get; set; }

        /// <summary>
        /// Gets or sets the pipe line stage.
        /// </summary>
        [DataMember(Name = "hs_pipeline_stage")]
        public string PipeLineStage { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        [DataMember(Name = "hs_ticket_priority")]
        public TicketPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// </summary>
        [DataMember(Name = "hubspot_owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        [DataMember]
        public string Subject { get; set; }
    }
}