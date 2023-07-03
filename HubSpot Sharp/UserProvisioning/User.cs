using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class User
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string RoleId { get; set; }

        public string PrimaryTeamId { get; set; }

        public IList<string> SecondaryTeamIds { get; set; }

        public bool? SendWelcomeEmail { get; set; }
    }
}
