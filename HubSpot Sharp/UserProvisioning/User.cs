using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string RoleId { get; set; }

        [DataMember]
        public string PrimaryTeamId { get; set; }

        [DataMember]
        public IList<string> SecondaryTeamIds { get; set; }

        [DataMember]
        public bool? SendWelcomeEmail { get; set; }
    }
}
