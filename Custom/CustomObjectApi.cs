namespace HubSpot_Sharp.Custom
{
    using System.Collections.Generic;

    using HubSpot_Sharp;

    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class CustomObjectApi
    {
        /// <summary>
        /// Contains functions for interacting with custom object endpoints.
        /// </summary>
        private readonly HubSpotClient client;

        /// <param name="client">The HubSpot client to make requests with.</param>
        public CustomObjectApi(HubSpotClient client)
        {
            this.client = client;
        }

        public AssociationsList GetAssociations(string objectType, long objectId, string toObjectType)
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}";
            return client.Execute<AssociationsList>(path);
        }

        public void Associate(
            string objectType,
            long objectId,
            string toObjectType,
            long toObjectId,
            string associationType)
        {
            var path =
                $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}/{toObjectId}/{associationType}";
            client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(
            string objectType,
            long objectId,
            string toObjectType,
            long toObjectId,
            string associationType)
        {
            var path =
                $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}/{toObjectId}/{associationType}";
            client.Execute(path, Method.Delete);
        }

        /// <summary>
        /// Creates a custom object of the specified type
        /// </summary>
        public void Create<T>(T obj)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var path = "/crm/v3/objects/" + obj.ObjectId;
            client.Execute<T>(path, Method.Post, PropertyBag<T>.Pack(obj));
        }

        public T Read<T>(string objectType, long objectId)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}";
            return client.Execute<PropertyBag<T>>(path).Unpack();
        }

        public ListResult<T> List<T>(string objectType, int limit = 10, string? after = null, IList<string>? properties = null)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {

            var path = $"/crm/v3/objects/{objectType}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return client.Execute<ListResult<T>>(options);
        }

        public T Update<T>(T obj)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{obj.ObjectId}/{obj.Id}";
            return client.Execute<PropertyBag<T>>(path, Method.Patch, PropertyBag<T>.Pack(obj)).Unpack();
        }

        public void Archive(string objectType, long objectId)
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}";
            client.Execute(path, Method.Delete);
        }

        public void Archive<T>(T obj)
            where T : HubSpotBaseModel, ICustomHubSpotObject
        {
            Archive(obj.ObjectId, obj.Id!.Value);
        }

        public BatchResult<T> CreateBatch<T>(BatchInputs<T> objects)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/batch/create";
            return client.Execute<BatchResult<T>>(path, Method.Post, objects);
        }

        public BatchResult<T> CreateBatch<T>(IList<T> objects)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            return CreateBatch(new BatchInputs<T>(objects));
        }

        public BatchResult<T> ReadByProperties<T>(BatchIdInputs options)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/batch/read";
            return client.Execute<BatchResult<T>>(path, Method.Post, options);
        }

        public BatchResult<T> UpdateBatch<T>(BatchInputs<T> objects)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/batch/update";
            return client.Execute<BatchResult<T>>(path, Method.Post, objects);
        }

        public BatchResult<T> UpdateBatch<T>(IList<T> objects)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            return UpdateBatch(new BatchInputs<T>(objects));
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}