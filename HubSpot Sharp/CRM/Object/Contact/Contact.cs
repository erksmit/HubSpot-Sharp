// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Contact.cs" company="">
//   
// </copyright>
// <summary>
//   The contact.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp.CRM.Object.Contact
{
    /// <summary>
    /// The base class model for a contact in HubSpot.
    /// </summary>
    [DataContract]
    [AssociationId("CONTACT")]
    [ApiPathName("contacts")]
    public class Contact : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the email of the contact.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        [DataMember]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        [DataMember]
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [DataMember]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [DataMember]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [DataMember(Name = "zipcode")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the secondary emails.
        /// </summary>
        [DataMember(Name = "hs_additional_emails")]
        [HubSpotEnumeration]
        public IList<string> SecondaryEmails { get; set; }
    }
}