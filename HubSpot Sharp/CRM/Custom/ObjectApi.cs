namespace HubSpot_Sharp.CRM.Custom
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class ObjectApi
    {
        /// <summary>
        /// Contains functions for interacting with custom object endpoints.
        /// </summary>
        private readonly HubSpotClient client;

        /// <param name="client">The HubSpot client to make requests with.</param>
        public ObjectApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<Association> GetAssociations(string objectType, long objectId, string toObjectType)
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}";
            return this.client.Execute<ListResult<Association>>(path);
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
            this.client.Execute(path, Method.Put);
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
            this.client.Execute(path, Method.Delete);
        }

        /// <summary>
        /// Creates a custom object of the specified type
        /// </summary>
        public void Create<T>(T obj)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var path = "/crm/v3/objects/" + obj.ObjectId;
            using var pack = PropertyBag<T>.Pack(obj);
            this.client.Execute<T>(path, Method.Post, pack);
        }

        public T Read<T>(string objectType, long objectId) where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}";
            return this.client.Execute<PropertyBag<T>>(path).Unpack();
        }

        public T Read<T>(long objectId) where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            string objectType = new T().ObjectId;
            return this.Read<T>(objectType, objectId);
        }

        public ListResult<PropertyBag<T>> List<T>(string objectType, int limit = 10, string? after = null, IList<string>? properties = null) where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return this.client.Execute<ListResult<PropertyBag<T>>>(options);
        }
        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            string objectType = new T().ObjectId;
            return this.List<T>(objectType, limit, after, properties);
        }

        public T Update<T>(T obj) where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{obj.ObjectId}/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(string objectType, long objectId)
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}";
            this.client.Execute(path, Method.Delete);
        }
        public void Archive<T>(T obj) where T : HubSpotObject, ICustomHubSpotObject => this.Archive(obj.ObjectId, obj.Id!.Value);

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> objects)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, objects);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(IList<T> objects)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            return this.CreateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }

        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/batch/read";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, options);
        }

        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> objects)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, objects);
        }

        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> objects)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            return this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var objectType = new T().ObjectId;
            var path = $"/crm/v3/objects/{objectType}/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}