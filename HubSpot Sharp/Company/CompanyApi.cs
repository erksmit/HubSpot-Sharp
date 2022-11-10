namespace HubSpot_Sharp.Company
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
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
        public AssociationsList GetAssociations(long companyId, string toObjectType)
        {
            var path = $"/crm/v4/objects/companies/{companyId}/associations/{toObjectType}";
            return client.Execute<AssociationsList>(path);
        }

        /// <summary>
        /// Associate a company with another object.
        /// </summary>
        public void Associate(long companyId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/companies/{companyId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Put);
        }

        /// <summary>
        /// Remove an association between two objects
        /// </summary>
        public void RemoveAssociation(long companyId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/companies/{companyId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Delete);
        }

        public ListResult<T> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : BaseCompany, new()
        {
            var path = "/crm/v3/objects/companies";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));

            return client.Execute<ListResult<T>>(options);
        }

        /// <summary>
        /// Create a company with the given properties and return a copy of the object, including the ID.
        /// </summary>
        public T Create<T>(T company) where T : BaseCompany, new()
        {
            const string Path = "/crm/v3/objects/companies";
            return client.Execute<PropertyBag<T>>(Path, Method.Post, PropertyBag<T>.Pack(company)).Unpack();
        }

        /// <summary>
        /// Read a company by it's id.
        /// </summary>
        public T Read<T>(long id)
            where T : BaseCompany, new()
        {
            var path = "/crm/v3/objects/companies/" + id;
            return client.Execute<PropertyBag<T>>(path).Unpack();
        }

        /// <summary>
        /// Update a company using it's id.
        /// </summary>
        public T Update<T>(T company)
            where T : BaseCompany, new()
        {
            var path = "/crm/v3/objects/companies/" + company.Id;
            return client.Execute<PropertyBag<T>>(path, Method.Patch, PropertyBag<T>.Pack(company)).Unpack();
        }

        /// <summary>
        /// Move an Object identified by <paramref name="id" /> to the recycling bin.
        /// </summary>
        public void Archive(long id)
        {
            var path = "/crm/v3/objects/companies/" + id;
            client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(BatchIdInputs inputs)
        {
            const string Path = "/crm/v3/objects/companies/batch/archive";
            client.Execute(Path, Method.Delete, inputs);
        }

        /// <summary>
        /// Create a batch of companies.
        /// </summary>
        public BatchResult<T> CreateBatch<T>(BatchInputs<T> inputs) where T : BaseCompany, new()
        {
            const string Path = "/crm/v3/objects/companies/batch/create";
            return client.Execute<BatchResult<T>>(Path, Method.Post, inputs);
        }

        public BatchResult<T> CreateBatch<T>(IList<T> inputs)
            where T : BaseCompany, new() =>
            CreateBatch(new BatchInputs<T>(inputs));

        /// <summary>
        /// Updates a batch of companies.
        /// </summary>
        /// =
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<T> UpdateBatch<T>(BatchInputs<T> companies) where T : BaseCompany, new()
        {
            string path = "/crm/v3/objects/companies/batch/update";
            return client.Execute<BatchResult<T>>(path, Method.Post, companies);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<T> UpdateBatch<T>(IList<T> companies) where T : BaseCompany, new() =>
            UpdateBatch(new BatchInputs<T>(companies));

        /// <summary>
        /// Gets a batch of companies via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<T> ReadByProperties<T>(BatchIdInputs inputs) where T : BaseCompany, new()
        {
            return client.Execute<BatchResult<T>>("/crm/v3/objects/companies/batch/read", Method.Post, inputs);
        }

        public SearchResults<T> Search<T>(SearchOptions options) where T : BaseCompany, new()
        {
            string path = "/crm/v3/objects/companies/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}