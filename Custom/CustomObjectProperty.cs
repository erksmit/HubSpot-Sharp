namespace HubSpot_Sharp.Custom
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents a property of a custom HubSpot object schema
    /// </summary>
    [DataContract]
    public class CustomObjectProperty
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
        public CustomObjectFieldTypeEnum FieldType { get; set; }

        /// <summary>
        /// The input method for this property
        /// </summary>
        [DataMember(Name = "type")]
        public CustomObjectTypeEnum Type { get; set; }

        /// <summary>
        /// Whether the property requires a unique value.
        /// </summary>
        [DataMember(Name = "hasUniqueValue")]
        public bool HasUniqueValue { get; set; }

        /// <summary>
        /// Allowed values for properties with Type <see cref="CustomObjectFieldTypeEnum" />.Enumeration.
        /// </summary>
        [DataMember(Name = "options")]
        public IList<CustomObjectOptions> Options { get; set; }
    }
}