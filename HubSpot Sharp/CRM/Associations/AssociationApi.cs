// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssociationApi.cs" company="">
//   
// </copyright>
// <summary>
//   The association api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Associations.Schema;

namespace HubSpot_Sharp.CRM.Associations
{
    /// <summary>
    /// The associations api.
    /// </summary>
    public class AssociationApi
    {
        /// <summary>
        /// The HubSpot client to make requests with.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public AssociationApi(HubSpotClient client)
        {
            this.client = client;
            Schema = new AssociationSchemaApi(client);
        }

        /// <summary>
        /// Gets the association schema api
        /// </summary>
        public AssociationSchemaApi Schema { get; }
    }
}