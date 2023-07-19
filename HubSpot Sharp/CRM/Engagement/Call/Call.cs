using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.CRM.Engagement.Call
{
    [DataContract]
    public class Call : HubSpotObject
    {
        [DataMember]
        public DateTime TimeStamp { get; set; }
        
        [DataMember]
        public string Title { get; set; }
        
        [DataMember]
        public long OwnerId { get; set; }
        
        [DataMember]
        public string Body { get; set; }
        
        [DataMember]
        public int Duration { get; set; }
        
        [DataMember]
        public string FromNumber { get; set; }
        
        [DataMember]
        public string ToNumber { get; set; }
        
        [DataMember]
        public string RecordingUrl { get; set; }
        
        [DataMember]
        public string Status { get; set; }
    }
}
