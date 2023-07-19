// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The product api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.Product
{
    /// <summary>
    /// The product api.
    /// </summary>
    public class ProductApi : CrmObjectBaseApi<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public ProductApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}