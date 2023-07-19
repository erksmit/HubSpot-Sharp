// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Company.cs" company="">
//   
// </copyright>
// <summary>
//   The base class for a company in HubSpot.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Company
{
    /// <summary>
    /// The base class for a company in HubSpot.
    /// </summary>
    [DataContract]
    [AssociationId("COMPANY")]
    [ApiPathName("companies")]
    public class Company : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the domain url of the company.
        /// </summary>
        [DataMember]
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the website of the company.
        /// </summary>
        [DataMember]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the description of the company.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the country the company resides in.
        /// </summary>
        [DataMember]
        public string Country { get; set; }
    }
}