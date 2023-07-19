// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TicketPriority.cs" company="">
//   
// </copyright>
// <summary>
//   The ticket priority.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Ticket
{
    /// <summary>
    /// The ticket priority.
    /// </summary>
    [DataContract]
    public enum TicketPriority
    {
        /// <summary>
        /// The low.
        /// </summary>
        [EnumMember(Value = "LOW")]
        Low,

        /// <summary>
        /// The medium.
        /// </summary>
        [EnumMember(Value = "MEDIUM")]
        Medium,

        /// <summary>
        /// The high.
        /// </summary>
        [EnumMember(Value = "HIGH")]
        High
    }
}