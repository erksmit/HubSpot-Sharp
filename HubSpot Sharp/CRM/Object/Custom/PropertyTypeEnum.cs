// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyTypeEnum.cs" company="">
//   
// </copyright>
// <summary>
//   The property type enum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Custom
{
    /// <summary>
    /// Enum describing the data type of a property.
    /// </summary>
    [DataContract]
    public enum PropertyTypeEnum
    {
        /// <summary>
        /// A field containing binary options (e.g.,  Yes or No, True or False).
        /// </summary>
        Bool,

        /// <summary>
        /// A string representing a set of options, separated by semicolons.
        /// </summary>
        Enumeration,

        /// <summary>
        /// An ISO 8601 formatted value representing a specific day, month, and year.
        /// </summary>
        Date,

        /// <summary>
        /// An ISO 8601 formatted value representing a specific day, month, year and time of day. The HubSpot app will not display
        /// the time of day.
        /// </summary>
        DateTime,

        /// <summary>
        /// A plain text strings, limited to 65,536 characters.
        /// </summary>
        String,

        /// <summary>
        /// A number value containing numeric digits and at most one decimal.
        /// </summary>
        Number
    }
}