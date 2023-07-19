namespace HubSpot_Sharp.CRM.Engagement
{
    public abstract class EngagementBaseApi<THubType> : CrudBaseApi<THubType> where THubType : HubSpotObject, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrudBaseApi{THubType}"/> class with the specified type.
        /// </summary>
        /// <param name="client">
        /// The HubSpot client to make requests with.
        /// </param>
        internal EngagementBaseApi(HubSpotClient client) : base(client, "engagements")
        {
        }
    }
}