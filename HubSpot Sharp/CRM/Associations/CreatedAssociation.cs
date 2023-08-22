using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.CRM.Associations
{
    [DataContract]
    public class CreatedAssociation
    {
        [DataMember]
        public string FromObjectTypeId { get; set; }

        [DataMember]
        public int FromObjectId { get; set; }


        [DataMember]
        public string ToObjectTypeId { get; set; }
        
        [DataMember]
        public int ToObjectId { get; set; }

        [DataMember]
        public IList<string> Labels { get; set; }
    }
}
