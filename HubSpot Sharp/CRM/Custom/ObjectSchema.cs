namespace HubSpot_Sharp.CRM.Custom
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a schema used to create a custom HubSpot object.
    /// </summary>
    [DataContract]
    public class ObjectSchema
    {
        /// <summary>
        /// The internal name used to identify this object.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The display labels for the object.
        /// </summary>
        [DataMember(Name = "labels")]
        public ObjectLabels Labels { get; set; }

        /// <summary>
        /// The property used for naming individual custom object records.
        /// </summary>
        [DataMember(Name = "primaryDisplayProperty")]
        public string PrimaryDisplayProperty { get; set; }

        /// <summary>
        /// The properties that appear on individual records under the primaryDisplayProperty.
        /// </summary>
        [DataMember(Name = "secondaryDisplayProperties")]
        public IList<string> SecondaryDisplayProperties { get; set; }

        /// <summary>
        /// The properties that are indexed for searching in HubSpot.
        /// </summary>
        [DataMember(Name = "searchableProperties")]
        public IList<string> SearchableProperties { get; set; }

        /// <summary>
        /// The properties that are required when creating a new custom object record.
        /// </summary>
        [DataMember(Name = "requiredProperties")]
        public IList<string> RequiredProperties { get; set; }

        /// <summary>
        /// The properties of this object
        /// </summary>
        [DataMember(Name = "properties")]
        public IList<ObjectProperty> Properties { get; set; }

        /// <summary>
        /// Other HubSpot objects to associate with this object type.
        /// </summary>
        [DataMember(Name = "associatedObjects")]
        public IList<string> AssociatedObjects { get; set; }
    }
}