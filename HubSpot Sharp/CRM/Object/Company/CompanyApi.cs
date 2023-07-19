// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyApi.cs" company="">
//   
// </copyright>
// <summary>
//   The company api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.Company
{
    /// <summary>
    /// The company api.
    /// </summary>
    public class CompanyApi : CrmObjectBaseApi<Company>
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
    }
}