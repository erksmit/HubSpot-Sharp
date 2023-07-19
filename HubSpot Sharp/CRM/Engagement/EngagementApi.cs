using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HubSpot_Sharp.CRM.Engagement.Call;

namespace HubSpot_Sharp.CRM.Engagement
{
    public class EngagementApi
    {
        public CallApi Call { get; }

        public EngagementApi(HubSpotClient client)
        {
            Call = new CallApi(client);
        }
    }
}
