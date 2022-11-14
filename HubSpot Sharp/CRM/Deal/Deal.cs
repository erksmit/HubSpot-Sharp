using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Deal
{
    [DataContract]
    public class Deal : HubSpotObject
    {
        [DataMember(Name = "amount")]
        public double Amount { get; set; }
        
        [DataMember(Name = "closedate")]
        public DateTime CloseDate { get; set; }
        
        [DataMember(Name = "createdate")]
        public DateTime CreateDate { get; set; }
        
        [DataMember(Name = "dealname")]
        public string Name { get; set; }
        
        [DataMember(Name = "dealstage")]
        public string Stage { get; set; }
        
        [DataMember(Name = "hubspot_owner_id")]
        public long OwnerId { get; set; }

        [DataMember(Name = "pipeline")]
        public string PipeLine { get; set; }
    }
}
