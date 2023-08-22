// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TicketApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The ticket api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.Object.Ticket
{
    /// <summary>
    /// The ticket api.
    /// </summary>
    public class TicketApi : CrmContentApi<Ticket>
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