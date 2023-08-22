// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The contact api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.CRM.Object.Contact
{
    /// <summary>
    /// The contact api.
    /// </summary>
    public class ContactApi : CrmContentApi<Contact>
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

        /// <summary>
        /// Merges two contacts of the same type
        /// </summary>
        /// <typeparam name="T">The type of the contacts</typeparam>
        /// <param name="options">The parameters of the contacts</param>
        /// <returns>A task that returns the newly merged contact on completion.</returns>
        public async Task<T> Merge<T>(MergeOptions options) where T : Contact
        {
            const string Path = "/crm/v3/objects/contacts/merge";
            var result = await Client.Execute<PropertyBag<T>>(Path, HttpMethod.Post, options);
            return result.GetProperties();
        }
    }
}