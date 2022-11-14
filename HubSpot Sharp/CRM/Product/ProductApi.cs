namespace HubSpot_Sharp.CRM.Product
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class ProductApi
    {
        private readonly HubSpotClient client;

        public ProductApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : Product, new()
        {
            const string Path = "/crm/v3/objects/products";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return this.client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        public T Create<T>(T obj) where T : Product, new()
        {
            const string Path = "/crm/v3/objects/products";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        public T Read<T>(long id)
            where T : Product, new()
        {
            var path = $"/crm/v3/objects/products/{id}";
            return this.client.Execute<PropertyBag<T>>(path, Method.Get).Unpack();
        }

        public T Update<T>(T obj)
            where T : Product, new()
        {
            var path = $"/crm/v3/objects/products/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/products/{id}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(SelectByPropertiesOptions inputs)
        {
            const string path = "/crm/v3/objects/products/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs)
            where T : Product, new()
        {
            const string path = "/crm/v3/objects/products/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of products.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> products)
            where T : Product, new()
        {
            string path = "/crm/v3/objects/products/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, products);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> products)
            where T : Product, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(products)));

        /// <summary>
        /// Gets a batch of products via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : Product, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/products/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : Product, new()
        {
            string path = "/crm/v3/objects/products/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}