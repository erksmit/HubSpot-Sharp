namespace HubSpot_Sharp.CRM.Company
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class CompanyApi
    {
        private readonly HubSpotClient client;

        public CompanyApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// List associations of a company by type.
        /// </summary>
        public ListResult<Association> GetAssociations(long companyId, string toObjectType)
        {
            var path = $"/crm/v4/objects/companies/{companyId}/associations/{toObjectType}";
            return this.client.Execute<ListResult<Association>>(path);
        }

        /// <summary>
        /// Associate a company with another object.
        /// </summary>
        public void Associate(long companyId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/companies/{companyId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Put);
        }

        /// <summary>
        /// Remove an association between two objects
        /// </summary>
        public void RemoveAssociation(long companyId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/companies/{companyId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Delete);
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : Company, new()
        {
            var path = "/crm/v3/objects/companies";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));

            return this.client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        /// <summary>
        /// Create a company with the given properties and return a copy of the object, including the ID.
        /// </summary>
        public T Create<T>(T company) where T : Company, new()
        {
            const string Path = "/crm/v3/objects/companies";
            using var pack = PropertyBag<T>.Pack(company);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        /// <summary>
        /// Read a company by it's id.
        /// </summary>
        public T Read<T>(long id)
            where T : Company, new()
        {
            var path = "/crm/v3/objects/companies/" + id;
            return this.client.Execute<PropertyBag<T>>(path).Unpack();
        }

        /// <summary>
        /// Update a company using it's id.
        /// </summary>
        public T Update<T>(T company)
            where T : Company, new()
        {
            var path = "/crm/v3/objects/companies/" + company.Id;
            using var pack = PropertyBag<T>.Pack(company);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        /// <summary>
        /// Move an Object identified by <paramref name="id" /> to the recycling bin.
        /// </summary>
        public void Archive(long id)
        {
            var path = "/crm/v3/objects/companies/" + id;
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(ListInputs<IdInput> inputs)
        {
            const string Path = "/crm/v3/objects/companies/batch/archive";
            this.client.Execute(Path, Method.Post, inputs);
        }

        /// <summary>
        /// Create a batch of companies.
        /// </summary>
        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs) where T : Company, new()
        {
            const string Path = "/crm/v3/objects/companies/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(Path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(IList<T> inputs)
            where T : Company, new() =>
            this.CreateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(inputs)));

        /// <summary>
        /// Updates a batch of companies.
        /// </summary>
        /// =
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> companies) where T : Company, new()
        {
            string path = "/crm/v3/objects/companies/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, companies);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> companies) where T : Company, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(companies)));

        /// <summary>
        /// Gets a batch of companies via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions inputs) where T : Company, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/companies/batch/read", Method.Post, inputs);
        }

        public SearchResults<T> Search<T>(SearchOptions options) where T : Company, new()
        {
            string path = "/crm/v3/objects/companies/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}