using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class Team
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<string> UserIds { get; set; }

        public IList<string> SecondaryUserIds { get; set; }
    }
}
