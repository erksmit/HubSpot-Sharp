// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TicketApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The ticket api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.Ticket
{
    /// <summary>
    /// The ticket api.
    /// </summary>
    public class TicketApi : CrmObjectBaseApi<Ticket>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TicketApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public TicketApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}