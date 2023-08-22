// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmApi.cs" company="">
//   
// </copyright>
// <summary>
//   The crm api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Associations;
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
            Association = new AssociationApi(client);
        }

        /// <summary>
        /// Gets the objects api.
        /// </summary>
        public CrmObjectApi Object { get; }

        /// <summary>
        /// Gets the engagements api.
        /// </summary>
        public EngagementApi Engagement { get; }

        /// <summary>
        /// Gets the property api.
        /// </summary>
        public PropertyApi Property { get; }

        /// <summary>
        /// Gets the association api
        /// </summary>
        public AssociationApi Association { get; }
    }
}