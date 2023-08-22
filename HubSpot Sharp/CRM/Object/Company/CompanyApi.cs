// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyApi.cs" company="">
//   
// </copyright>
// <summary>
//   The company api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.CRM.Object.Company
{
    /// <summary>
    /// The company api.
    /// </summary>
    public class CompanyApi : CrmContentApi<Company>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public CompanyApi(HubSpotClient client)
            : base(client)
        {
        }

        /// <summary>
        /// Merges two companies of the same type
        /// </summary>
        /// <typeparam name="T">The type of the companies</typeparam>
        /// <param name="options">The parameters of the companies</param>
        /// <returns>A task that returns the newly merged company on completion.</returns>
        public async Task<T> Merge<T>(MergeOptions options) where T : Company
        {
            const string Path = "/crm/v3/objects/companies/merge";
            var result = await Client.Execute<PropertyBag<T>>(Path, HttpMethod.Post, options);
            return result.GetProperties();
        }
    }
}