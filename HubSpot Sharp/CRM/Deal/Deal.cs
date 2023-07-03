using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Deal
{
    [DataContract]
    [AssociationId("DEAL")]
    [ApiPathName("deals")]
    public class Deal : HubSpotObject
    {
        public double Amount { get; set; }
        
        public DateTime CloseDate { get; set; }
        
        public string Name { get; set; }
        
        public string Stage { get; set; }
        
        public long OwnerId { get; set; }

        public string PipeLine { get; set; }
    }
}
