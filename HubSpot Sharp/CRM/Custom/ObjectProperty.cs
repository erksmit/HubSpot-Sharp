// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectProperty.cs" company="">
//   
// </copyright>
// <summary>
//   Represents a property of a custom HubSpot object schema
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Custom
{
    /// <summary>
    /// Represents a property of a custom HubSpot object schema
    /// </summary>
    [DataContract]
    public class ObjectProperty
    {
        /// <summary>
        /// Gets or sets the internal name used to identify the property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display name used for this property.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the data type of the property.
        /// </summary>
        public PropertyFieldTypeEnum FieldType { get; set; }

        /// <summary>
        /// Gets or sets the input method for this property
        /// </summary>
        public PropertyTypeEnum Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the property requires a unique value.
        /// </summary>
        public bool HasUniqueValue { get; set; }

        /// <summary>
        /// Gets or sets a list of Allowed values, used for properties with Type <see cref="PropertyFieldTypeEnum" />.Enumeration.
        /// </summary>
        public IList<EnumerationOption> Options { get; set; }

        /// <summary>
        /// Gets or sets the Calculationformula which describes the formula of a calculated field. See <see href="https://developers.hubspot.com/docs/api/crm/properties#calculation-property-syntax">here</see> for more information.
        /// </summary>
        public string CalculationFormula { get; set; }
    }
}