using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    [DataContract]
    public class Role
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
