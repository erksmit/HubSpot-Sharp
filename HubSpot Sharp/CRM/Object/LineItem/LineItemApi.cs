// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineItemApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The LineItem api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.LineItem
{
    /// <summary>
    /// The LineItem api.
    /// </summary>
    public class LineItemApi : CrmObjectBaseApi<LineItem>
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