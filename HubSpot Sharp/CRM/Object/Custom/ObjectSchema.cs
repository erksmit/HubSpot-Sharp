// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectSchema.cs" company="">
//   
// </copyright>
// <summary>
//   Represents a schema used to create a custom HubSpot object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using HubSpot_Sharp.CRM.Property;

namespace HubSpot_Sharp.CRM.Custom
{
    /// <summary>
    /// Represents a schema used to create a custom HubSpot object.
    /// </summary>
    [DataContract]
    public class ObjectSchema
    {
        /// <summary>
        /// Gets or sets the internal name used to identify this object.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display labels for the object.
        /// </summary>
        [DataMember]
        public ObjectLabels Labels { get; set; }

        /// <summary>
        /// Gets or sets the property used for naming individual custom object records.
        /// </summary>
        [DataMember]
        public string PrimaryDisplayProperty { get; set; }

        /// <summary>
        /// Gets or sets the properties that appear on individual records under the primary display property.
        /// </summary>
        [DataMember]
        public IList<string> SecondaryDisplayProperties { get; set; }

        /// <summary>
        /// Gets or sets the properties that are indexed for searching in HubSpot.
        /// </summary>
        [DataMember]
        public IList<string> SearchableProperties { get; set; }

        /// <summary>
        /// Gets or sets the properties that are required when creating a new custom object record.
        /// </summary>
        [DataMember]
        public IList<string> RequiredProperties { get; set; }

        /// <summary>
        /// Gets or sets the properties of this object
        /// </summary>
        [DataMember]
        public IList<ObjectProperty> Properties { get; set; }

        /// <summary>
        /// Gets or sets the Other HubSpot objects to associate with this object type.
        /// </summary>
        [DataMember]
        public IList<string> AssociatedObjects { get; set; }
    }
}