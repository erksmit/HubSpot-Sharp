using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class Team
    {
        public Team(string id, string name, IList<string> userIds, IList<string> secondaryUserIds)
        {
            Id = id;
            Name = name;
            UserIds = userIds;
            SecondaryUserIds = secondaryUserIds;
        }

        [DataMember]
        public string Id { get; }

        [DataMember]
        public string Name { get; }

        [DataMember]
        public IList<string> UserIds { get; }

        [DataMember]
        public IList<string> SecondaryUserIds { get; }
    }
}
