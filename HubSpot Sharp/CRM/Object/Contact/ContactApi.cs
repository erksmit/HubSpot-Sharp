// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The contact api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.Contact
{
    /// <summary>
    /// The contact api.
    /// </summary>
    public class ContactApi : CrmObjectBaseApi<Contact>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public ContactApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}