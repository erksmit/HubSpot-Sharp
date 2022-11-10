namespace HubSpot_Sharp.Authentication
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class TokenInformation
    {
        [DataMember(Name = "userId")]
        public long UserId { get; set; }

        [DataMember(Name = "hubId")]
        public long HubId { get; set; }

        [DataMember(Name = "appId")]
        public long AppId { get; set; }

        [DataMember(Name = "scopes")]
        public IList<string> Scopes { get; set; }
    }
}