// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountDetails.cs" company="">
//   
// </copyright>
// <summary>
//   The account details.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    /// <summary>
    /// The account details.
    /// </summary>
    [DataContract]
    public class AccountDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDetails"/> class.
        /// </summary>
        /// <param name="portalId">
        /// The portal id.
        /// </param>
        /// <param name="timezone">
        /// The timezone.
        /// </param>
        /// <param name="companyCurrency">
        /// The company currency.
        /// </param>
        /// <param name="additionalCurrencies">
        /// The additional currencies.
        /// </param>
        /// <param name="utcOffset">
        /// The utc offset.
        /// </param>
        /// <param name="utcOffsetMilliseconds">
        /// The utc offset milliseconds.
        /// </param>
        /// <param name="uiDomain">
        /// The ui domain.
        /// </param>
        /// <param name="dataHostingLocation">
        /// The data hosting location.
        /// </param>
        [JsonConstructor]
        internal AccountDetails(
            long portalId,
            string timezone,
            string companyCurrency,
            IList<string> additionalCurrencies,
            string utcOffset,
            long utcOffsetMilliseconds,
            string uiDomain,
            string dataHostingLocation)
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

        /// <summary>
        /// Gets the portal id.
        /// </summary>
        [DataMember]
        public long PortalId { get; }

        /// <summary>
        /// Gets the timezone.
        /// </summary>
        [DataMember]
        public string Timezone { get; }

        /// <summary>
        /// Gets the company currency.
        /// </summary>
        [DataMember]
        public string CompanyCurrency { get; }

        /// <summary>
        /// Gets the additional currencies.
        /// </summary>
        [DataMember]
        public IList<string> AdditionalCurrencies { get; }

        /// <summary>
        /// Gets the utc offset.
        /// </summary>
        [DataMember]
        public string UtcOffset { get; }

        /// <summary>
        /// Gets the utc offset milliseconds.
        /// </summary>
        [DataMember]
        public long UtcOffsetMilliseconds { get; }

        /// <summary>
        /// Gets the ui domain.
        /// </summary>
        [DataMember]
        public string UiDomain { get; }

        /// <summary>
        /// Gets the data hosting location.
        /// </summary>
        [DataMember]
        public string DataHostingLocation { get; }
    }
}