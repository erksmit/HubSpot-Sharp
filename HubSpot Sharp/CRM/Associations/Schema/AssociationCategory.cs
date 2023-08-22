using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Associations.Schema
{
    [DataContract]
    public enum AssociationCategory
    {
        [EnumMember(Value = "HUBSPOT_DEFINED")]
        HubspotDefined,

        [EnumMember(Value = "USER_DEFINED")]
        UserDefined
    }
}
