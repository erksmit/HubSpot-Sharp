namespace HubSpot_Sharp.Custom
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents an option for a field of the <see cref="CustomObjectFieldTypeEnum" />.Enumeration type
    /// </summary>
    [DataContract]
    public class CustomObjectOptions
    {
        /// <summary>
        /// The display name for this option.
        /// </summary>
        [DataMember(Name = "label")]
        public string Label { get; set; }

        /// <summary>
        /// The internal value used to identify this option
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; set; }

        public CustomObjectOptions(string label, string value)
        {
            Label = label;
            Value = value;
        }

        public CustomObjectOptions()
        {
        }

        public static IList<CustomObjectOptions> FromTuples(params (string Label, string Name)[] values)
        {
            return values.Select(value => new CustomObjectOptions(value.Label, value.Name)).ToList();
        }
    }
}