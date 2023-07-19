using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.CRM.Engagement.Call
{
    public class CallApi : EngagementBaseApi<Call>
    {
        public CallApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}
