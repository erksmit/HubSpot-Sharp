// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineItemApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The LineItem api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.LineItem
{
    /// <summary>
    /// The LineItem api.
    /// </summary>
    public class LineItemApi : CrmBaseApi<LineItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineItemApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public LineItemApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}