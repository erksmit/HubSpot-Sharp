// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DealApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The deal api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.Deal
{
    /// <summary>
    /// The deal api.
    /// </summary>
    public class DealApi : CrmBaseApi<Deal>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DealApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public DealApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}