using System.Runtime.Serialization;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class AccountDetails
    {
        public long PortalId { get; set; }

        public string Timezone { get; set; }

        public string CompanyCurrency { get; set; }

        public IList<string> AdditionalCurrencies { get; set; }

        public string UtcOffset { get; set; }

        public long UtcOffsetMilliseconds { get; set; }

        public string UiDomain { get; set; }

        public string DataHostingLocation { get; set; }
    }
}
