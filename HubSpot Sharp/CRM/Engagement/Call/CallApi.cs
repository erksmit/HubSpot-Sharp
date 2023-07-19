// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CallApi.cs" company="">
//   
// </copyright>
// <summary>
//   The call api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.Engagement.Call
{
    /// <summary>
    /// The call api.
    /// </summary>
    public class CallApi : CrmObjectApi<Call>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public CallApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}