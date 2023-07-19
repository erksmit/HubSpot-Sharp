// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModificationMetaData.cs" company="">
//   
// </copyright>
// <summary>
//   The modification meta data.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    /// <summary>
    /// The modification meta data.
    /// </summary>
    [DataContract]
    public class ModificationMetaData
    {
        /// <summary>
        /// Gets or sets the read only options.
        /// </summary>
        [DataMember]
        public bool ReadOnlyOptions { get; set; }

        /// <summary>
        /// Gets or sets the read only value.
        /// </summary>
        [DataMember]
        public bool ReadOnlyValue { get; set; }

        /// <summary>
        /// Gets or sets the read only definition.
        /// </summary>
        [DataMember]
        public bool ReadOnlyDefinition { get; set; }

        /// <summary>
        /// Gets or sets the archivable.
        /// </summary>
        [DataMember]
        public bool Archivable { get; set; }
    }
}