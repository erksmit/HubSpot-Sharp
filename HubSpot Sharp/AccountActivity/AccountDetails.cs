using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class AccountDetails
    {
        [JsonConstructor]
        internal AccountDetails(long portalId, string timezone, string companyCurrency, IList<string> additionalCurrencies, string utcOffset, long utcOffsetMilliseconds, string uiDomain, string dataHostingLocation)
        {
            PortalId = portalId;
            Timezone = timezone;
            CompanyCurrency = companyCurrency;
            AdditionalCurrencies = additionalCurrencies;
            UtcOffset = utcOffset;
            UtcOffsetMilliseconds = utcOffsetMilliseconds;
            UiDomain = uiDomain;
            DataHostingLocation = dataHostingLocation;
        }

        [DataMember]
        public long PortalId { get; }

        [DataMember]
        public string Timezone { get; }

        [DataMember]
        public string CompanyCurrency { get; }

        [DataMember]
        public IList<string> AdditionalCurrencies { get; }

        [DataMember]
        public string UtcOffset { get; }

        [DataMember]
        public long UtcOffsetMilliseconds { get; }

        [DataMember]
        public string UiDomain { get; }

        [DataMember]
        public string DataHostingLocation { get; }
    }
}
