using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class Role
    {
        public Role(string id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember]
        public string Id { get; }

        [DataMember]
        public string Name { get; }
    }
}
