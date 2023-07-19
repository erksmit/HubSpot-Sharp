// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Quote.cs" company="">
//   
// </copyright>
// <summary>
//   The quote.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Quote
{
    /// <summary>
    /// The quote.
    /// </summary>
    [DataContract]
    [AssociationId("QUOTE")]
    [ApiPathName("quotes")]
    public class Quote : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [DataMember(Name = "hs_quote_amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        [DataMember(Name = "hs_quote_number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember(Name = "hs_status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the terms.
        /// </summary>
        [DataMember(Name = "hs_terms")]
        public string Terms { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "hs_title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// </summary>
        [DataMember(Name = "hubspot_owner_id")]
        public long OwnerId { get; set; }
    }
}