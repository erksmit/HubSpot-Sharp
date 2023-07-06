using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class ValidationInformationV3
    {
        [DataMember]
        public string Signature { get; set; }
        
        [DataMember]
        public DateTime TimeStamp { get; set; }
        
        [DataMember]
        public string Method { get; set; }
        
        [DataMember]
        public string Uri { get; set; }
        
        [DataMember]
        public string Body { get; set; }
    }
}
