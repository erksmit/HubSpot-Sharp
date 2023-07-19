using HubSpot_Sharp.CRM.Object;
using HubSpot_Sharp.CRM.Property;

namespace HubSpot_Sharp.CRM
{
    public class CrmApi
    {
        public CrmObjectApi Object { get; }

        public PropertyApi Property { get; }

        public CrmApi(HubSpotClient client)
        {
            Object = new CrmObjectApi(client);
            Property = new PropertyApi(client);
        }
    }
}
