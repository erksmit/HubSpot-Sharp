// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationOption.cs" company="">
//   
// </copyright>
// <summary>
//   Represents an option for a field of the enumeration type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    /// <summary>
    /// Represents an option for a field of the <see cref="PropertyFieldTypeEnum" />.Enumeration type
    /// </summary>
    [DataContract]
    public class EnumerationOption
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationOption"/> class using the provided label and value.
        /// </summary>
        /// <param name="label">
        /// The display name of the option.
        /// </param>
        /// <param name="value">
        /// The identifying value of the option
        /// </param>
        public EnumerationOption(string label, string value)
        {
            Label = label;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationOption" /> class.
        /// </summary>
        public EnumerationOption()
        {
        }

        /// <summary>
        /// Gets or sets the display name for this option.
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the internal value used to identify this option
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Creates a list of enumeration options from a set of tuple arguments
        /// </summary>
        /// <param name="values">
        /// The tuples to make enumeration options from
        /// </param>
        /// <returns>
        /// The created enumeration options.
        /// </returns>
        public static IList<EnumerationOption> FromTuples(params (string Label, string Name)[] values)
        {
            return values.Select(value => new EnumerationOption(value.Label, value.Name)).ToList();
        }
    }
}