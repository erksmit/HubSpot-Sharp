using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class Team
    {
        [DataMember]
        public string Id { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public IList<string> UserIds { get; set; }
        
        [DataMember]
        public IList<string> SecondaryUserIds { get; set; }
    }
}
