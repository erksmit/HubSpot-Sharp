using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.CRM.Object.Tax
{
    [DataContract]
    public enum TaxType
    {
        [EnumMember(Value = "PERCENT")]
        Percent
    }
}
