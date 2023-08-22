using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.Options
{
    [DataContract]
    public class MergeOptions
    {
        [DataMember]
        public string PrimaryObjectId { get; set; }
        
        [DataMember]
        public string objectIdToMerge { get; set; }
    }
}
