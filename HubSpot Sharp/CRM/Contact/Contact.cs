namespace HubSpot_Sharp.CRM.Contact
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Serialization;

    using Newtonsoft.Json;

    [DataContract]
    public class Contact : HubSpotObject
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "zip")]
        public string ZipCode { get; set; }

        [DataMember(Name = "hs_additional_emails")]
        [JsonConverter(typeof(EnumerationConverter))]
        public IList<string> SecondaryEmails { get; set; }
    }
}