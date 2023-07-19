// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The quote api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.Quote
{
    /// <summary>
    /// The quote api.
    /// </summary>
    public class QuoteApi : CrmObjectBaseApi<Quote>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public QuoteApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}