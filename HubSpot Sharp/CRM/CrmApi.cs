// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmApi.cs" company="">
//   
// </copyright>
// <summary>
//   The crm api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Engagement;
using HubSpot_Sharp.CRM.Object;
using HubSpot_Sharp.CRM.Property;

namespace HubSpot_Sharp.CRM
{
    /// <summary>
    /// The crm api.
    /// </summary>
    public class CrmApi
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        public CrmObjectApi Object { get; }

        /// <summary>
        /// Gets the engagement.
        /// </summary>
        public EngagementApi Engagement { get; }

        /// <summary>
        /// Gets the property.
        /// </summary>
        public PropertyApi Property { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrmApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public CrmApi(HubSpotClient client)
        {
            Object = new CrmObjectApi(client);
            Property = new PropertyApi(client);
            Engagement = new EngagementApi(client);
        }
    }
}