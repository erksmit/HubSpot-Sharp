namespace HubSpot_Sharp.CRM.Object
{
    public abstract class CrmObjectBaseApi<THubType> : CrudBaseApi<THubType> where THubType : HubSpotObject, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrmObjectBaseApi{THubType}"/> class with the specified type.
        /// </summary>
        /// <param name="client">
        /// The HubSpot client to make requests with.
        /// </param>
        internal CrmObjectBaseApi(HubSpotClient client) : base(client, "objects")
        {
        }
    }
}
