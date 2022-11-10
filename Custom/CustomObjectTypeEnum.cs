namespace HubSpot_Sharp.Custom
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum CustomObjectTypeEnum
    {
        /// <summary>
        /// A string representing a set of options, separated by semicolons.
        /// </summary>
        [EnumMember(Value = "enumeration")]
        Enumeration,

        /// <summary>
        /// An ISO 8601 formatted value representing a specific day, month, and year.
        /// </summary>
        [EnumMember(Value = "date")]
        Date,

        /// <summary>
        /// An ISO 8601 formatted value representing a specific day, month, year and time of day. The HubSpot app will not display
        /// the time of day.
        /// </summary>
        [EnumMember(Value = "dateTime")]
        DateTime,

        /// <summary>
        /// A plain text strings, limited to 65,536 characters.
        /// </summary>
        [EnumMember(Value = "string")]
        String,

        /// <summary>
        /// A number value containing numeric digits and at most one decimal.
        /// </summary>
        [EnumMember(Value = "number")]
        Number
    }
}