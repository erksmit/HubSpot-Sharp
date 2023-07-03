using System.Runtime.Serialization;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class DailyUsage
    {
        public string Name { get; set; }

        public long UsageLimit { get; set; }

        public long CurrentUsage { get; set; }

        public DateTime CollectedAt { get; set; }

        public string FetchStatus { get; set; }

        public DateTime ResetsAt { get; set; }
    }
}
