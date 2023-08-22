using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpot_Sharp.CRM.Object.Tax
{
    public class TaxApi : CrmContentApi<Tax>
    {
        public TaxApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}
