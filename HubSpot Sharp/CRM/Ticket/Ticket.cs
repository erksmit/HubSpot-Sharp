using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Ticket
{
    [DataContract]
    [AssociationId("TICKET")]
    [ApiPathName("tickets")]
    public class Ticket : HubSpotObject
    {
        [DataMember(Name = "hs_pipeline")]
        public string Pipeline { get; set; }
        
        [DataMember(Name = "hs_pipeline_stage")]
        public string PipeLineStage { get; set; }
        
        [DataMember(Name = "hs_ticket_priority")]
        public TicketPriority Priority { get; set; }
        
        [DataMember(Name = "hubspot_owner_id")]
        public long OwnerId { get; set; }
        
        [DataMember]
        public string Subject { get; set; }
    }
}
