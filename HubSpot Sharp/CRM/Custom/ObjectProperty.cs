namespace HubSpot_Sharp.CRM.Custom
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a property of a custom HubSpot object schema
    /// </summary>
    [DataContract]
    public class ObjectProperty
    {
        /// <summary>
        /// The internal name used to identify the property.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The display name used for this property.
        /// </summary>
        [DataMember(Name = "label")]
        public string Label { get; set; }

        /// <summary>
        /// The data type of the property.
        /// </summary>
        [DataMember(Name = "fieldType")]
        public ObjectFieldTypeEnum FieldType { get; set; }

        /// <summary>
        /// The input method for this property
        /// </summary>
        [DataMember(Name = "type")]
        public ObjectTypeEnum Type { get; set; }

        /// <summary>
        /// Whether the property requires a unique value.
        /// </summary>
        [DataMember(Name = "hasUniqueValue")]
        public bool HasUniqueValue { get; set; }

        /// <summary>
        /// Allowed values for properties with Type <see cref="ObjectFieldTypeEnum" />.Enumeration.
        /// </summary>
        [DataMember(Name = "options")]
        public IList<EnumerationOption> Options { get; set; }
    }
}