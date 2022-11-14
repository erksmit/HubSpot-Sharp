namespace HubSpot_Sharp.CRM.Custom
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents an option for a field of the <see cref="ObjectFieldTypeEnum" />.Enumeration type
    /// </summary>
    [DataContract]
    public class EnumerationOption
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

        public EnumerationOption(string label, string value)
        {
            this.Label = label;
            this.Value = value;
        }

        public EnumerationOption()
        {
        }

        public static IList<EnumerationOption> FromTuples(params (string Label, string Name)[] values)
        {
            return values.Select(value => new EnumerationOption(value.Label, value.Name)).ToList();
        }
    }
}