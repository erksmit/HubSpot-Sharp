using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class DailyUsage
    {
        [JsonConstructor]
        internal DailyUsage(string name, long usageLimit, long currentUsage, DateTime collectedAt, string fetchStatus, DateTime resetsAt)
        {
            Name = name;
            UsageLimit = usageLimit;
            CurrentUsage = currentUsage;
            CollectedAt = collectedAt;
            FetchStatus = fetchStatus;
            ResetsAt = resetsAt;
        }

        [DataMember]
        public string Name { get; }
        
        [DataMember]
        public long UsageLimit { get; }
        
        [DataMember]
        public long CurrentUsage { get; }
        
        [DataMember]
        public DateTime CollectedAt { get; }
        
        [DataMember]
        public string FetchStatus { get; }
        
        [DataMember]
        public DateTime ResetsAt { get; }
    }
}
