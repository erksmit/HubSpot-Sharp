namespace HubSpot_Sharp.CRM.LineItem
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class LineItemApi
    {
        private readonly HubSpotClient client;

        public LineItemApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<Association> GetAssociations(long lineItemId, string toObjectType, int limit = 500, string? after = null)
        {
            var path = $"/crm/v4/objects/line_items/{lineItemId}/associations/{toObjectType}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit.ToString());
            if (after != null)
                options.AddParam("after", after);

            return this.client.Execute<ListResult<Association>>(options);
        }

        public void Associate(long lineItemId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/line_items/{lineItemId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(long lineItemId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/line_items/{lineItemId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Delete);
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : LineItem, new()
        {
            const string Path = "/crm/v3/objects/line_items";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return this.client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        public T Create<T>(T obj) where T : LineItem, new()
        {
            const string Path = "/crm/v3/objects/line_items";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        public T Read<T>(long id)
            where T : LineItem, new()
        {
            var path = $"/crm/v3/objects/line_items/{id}";
            return this.client.Execute<PropertyBag<T>>(path).Unpack();
        }

        public T Update<T>(T obj)
            where T : LineItem, new()
        {
            var path = $"/crm/v3/objects/line_items/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/line_items/{id}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(SelectByPropertiesOptions inputs)
        {
            const string path = "/crm/v3/objects/line_items/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs)
            where T : LineItem, new()
        {
            const string path = "/crm/v3/objects/line_items/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of line_items.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> lineItems)
            where T : LineItem, new()
        {
            string path = "/crm/v3/objects/line_items/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, lineItems);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> lineItems)
            where T : LineItem, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(lineItems)));

        /// <summary>
        /// Gets a batch of line_items via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : LineItem, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/line_items/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : LineItem, new()
        {
            string path = "/crm/v3/objects/line_items/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}