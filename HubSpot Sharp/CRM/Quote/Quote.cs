using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Quote
{
    [DataContract]
    [AssociationId("QUOTE")]
    [ApiPathName("quotes")]
    public class Quote : HubSpotObject
    {
        [DataMember(Name = "hs_quote_amount")]
        public double Amount { get; set; }
        
        [DataMember(Name = "hs_quote_number")]
        public string Number { get; set; }

        [DataMember(Name = "hs_status")]
        public string Status { get; set; }
        
        [DataMember(Name = "hs_terms")]
        public string Terms { get; set; }
        
        [DataMember(Name = "hs_title")]
        public string Title { get; set; }

        [DataMember(Name = "hubspot_owner_id")]
        public long OwnerId { get; set; }
    }
}
