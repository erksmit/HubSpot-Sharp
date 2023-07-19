using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Deal
{

    [AssociationId("DEAL")]
    [ApiPathName("deals")]
    [DataContract]
    public class Deal : HubSpotObject
    {
        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public DateTime CloseDate { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Stage { get; set; }

        [DataMember]
        public long OwnerId { get; set; }

        [DataMember]
        public string PipeLine { get; set; }
    }
}
