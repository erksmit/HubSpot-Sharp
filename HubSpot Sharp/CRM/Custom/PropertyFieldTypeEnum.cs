// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyFieldTypeEnum.cs" company="">
//   
// </copyright>
// <summary>
//   The property field type enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Custom
{
    /// <summary>
    /// Enum describing the input method users can use to input values for the property
    /// </summary>
    [DataContract]
    public enum PropertyFieldTypeEnum
    {
        /// <summary>
        /// An input that will allow users to select one of either Yes or No. When used in a form, it will be displayed as a single
        /// checkbox.
        /// </summary>
        BooleanCheckBox,

        /// <summary>
        /// A custom equation that can calculate values based on other property values and/or associations.
        /// </summary>
        [EnumMember(Value = "calculation_equation")]
        CalculationEquation,

        /// <summary>
        /// A list of checkboxes that will allow a user to select multiple options from a set of options allowed for the property.
        /// </summary>
        CheckBox,

        /// <summary>
        /// A date value, displayed as a date picker.
        /// </summary>
        Date,

        /// <summary>
        /// Allows for a file to be uploaded to a form. Stored and displayed as a URL link to the file.
        /// </summary>
        File,

        /// <summary>
        /// A string of numerals or numbers written in decimal or scientific notation.
        /// </summary>
        Number,

        /// <summary>
        /// An input that will allow users to select one of a set of options allowed for the property. When used in a form, this
        /// will be displayed as a set of radio buttons.
        /// </summary>
        Radio,

        /// <summary>
        /// A dropdown input that will allow users to select one of a set of options allowed for the property.
        /// </summary>
        Select,

        /// <summary>
        /// A plain text string, displayed in a single line text input.
        /// </summary>
        Text,

        /// <summary>
        /// A plain text string, displayed as a multi-line text input.
        /// </summary>
        TextArea,

        /// <summary>
        /// A string, rendered as sanitized html, that enables the use of a rich text editor for the property.
        /// </summary>
        Html
    }
}