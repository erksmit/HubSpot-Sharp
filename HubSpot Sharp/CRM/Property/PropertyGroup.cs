// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyGroup.cs" company="">
//   
// </copyright>
// <summary>
//   The property group.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    /// <summary>
    /// The property group.
    /// </summary>
    [DataContract]
    public class PropertyGroup
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order.
        /// </summary>
        [DataMember]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        [DataMember]
        public string Label { get; set; }
    }
}