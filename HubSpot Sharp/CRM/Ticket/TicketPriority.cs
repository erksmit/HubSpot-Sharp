using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Ticket
{
    [DataContract]
    public enum TicketPriority
    {
        [EnumMember(Value = "LOW")]
        Low,

        [EnumMember(Value = "MEDIUM")]
        Medium,

        [EnumMember(Value = "HIGH")]
        High
    }
}
