// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuoteApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The quote api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.Quote
{
    /// <summary>
    /// The quote api.
    /// </summary>
    public class QuoteApi : CrmBaseApi<Quote>
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