// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyInformation.cs" company="">
//   
// </copyright>
// <summary>
//   The property information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    /// <summary>
    /// The property information.
    /// </summary>
    [DataContract]
    public class PropertyInformation : ObjectProperty
    {
        /// <summary>
        /// Gets or sets the group name.
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the hidden.
        /// </summary>
        [DataMember]
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets the modification meta data.
        /// </summary>
        [DataMember]
        public ModificationMetaData ModificationMetaData { get; set; }

        /// <summary>
        /// Gets or sets the display order.
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the form field.
        /// </summary>
        [DataMember]
        public bool FormField { get; set; }

        /// <summary>
        /// Gets or sets the calculated.
        /// </summary>
        [DataMember]
        public bool Calculated { get; set; }

        /// <summary>
        /// Gets or sets the archived.
        /// </summary>
        [DataMember]
        public bool Archived { get; set; }

        /// <summary>
        /// Gets or sets the external options.
        /// </summary>
        [DataMember]
        public bool ExternalOptions { get; set; }
    }
}