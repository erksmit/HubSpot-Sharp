namespace HubSpot_Sharp.Custom
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum CustomObjectFieldTypeEnum
    {
        /// <summary>
        /// An input that will allow users to select one of either Yes or No. When used in a form, it will be displayed as a single
        /// checkbox.
        /// </summary>
        [EnumMember(Value = "booleancheckbox")]
        BooleanCheckBox,

        /// <summary>
        /// A list of checkboxes that will allow a user to select multiple options from a set of options allowed for the property.
        /// </summary>
        [EnumMember(Value = "checkbox")]
        CheckBox,

        /// <summary>
        /// A date value, displayed as a date picker.
        /// </summary>
        [EnumMember(Value = "date")]
        Date,

        /// <summary>
        /// Allows for a file to be uploaded to a form. Stored and displayed as a URL link to the file.
        /// </summary>
        [EnumMember(Value = "file")]
        File,

        /// <summary>
        /// A string of numerals or numbers written in decimal or scientific notation.
        /// </summary>
        [EnumMember(Value = "number")]
        Number,

        /// <summary>
        /// An input that will allow users to select one of a set of options allowed for the property. When used in a form, this
        /// will be displayed as a set of radio buttons.
        /// </summary>
        [EnumMember(Value = "radio")]
        Radio,

        /// <summary>
        /// A dropdown input that will allow users to select one of a set of options allowed for the property.
        /// </summary>
        [EnumMember(Value = "select")]
        Select,

        /// <summary>
        /// A plain text string, displayed in a single line text input.
        /// </summary>
        [EnumMember(Value = "text")]
        Text,

        /// <summary>
        /// A plain text string, displayed as a multi-line text input.
        /// </summary>
        [EnumMember(Value = "textarea")]
        TextArea
    }
}