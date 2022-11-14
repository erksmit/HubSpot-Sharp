namespace HubSpot_Sharp.CRM.Custom
{
    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;

    using RestSharp;

    public class SchemaApi
    {
        /// <summary>
        /// Contains functions for interacting with custom schema endpoints.
        /// </summary>
        private readonly HubSpotClient client;

        /// <param name="client">The HubSpot client to make requests with.</param>
        public SchemaApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Creates a custom object schema using the provided schema.
        /// </summary>
        /// <returns>A <see cref="SchemaInformation" /> with information about the created schema.</returns>
        public SchemaInformation Create(ObjectSchema schema)
        {
            return this.client.Execute<SchemaInformation>("/crm/v3/schemas", Method.Post, schema);
        }

        /// <summary>
        /// Returns an existing schema using the Fully qualified name or object type ID of your schema.
        /// </summary>
        public T Get<T>(string objectType)
            where T : HubSpotObject, ICustomHubSpotObject, new()
        {
            var path = "/crm/v3/schemas/" + objectType;
            return this.client.Execute<T>(path);
        }

        public ListResult<ObjectSchema> GetAll()
        {
            return this.client.Execute<ListResult<ObjectSchema>>("/crm/v3/schemas");
        }

        /// <summary>
        /// Update the details for an existing object schema.
        /// </summary>
        public SchemaInformation Update(ObjectSchema schema, string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            return this.client.Execute<SchemaInformation>(path, Method.Patch, schema);
        }

        /// <summary>
        /// Deletes a schema. Any existing records of this schema must be deleted first. Otherwise this call will fail.
        /// </summary>
        public void Archive(string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            this.client.Execute(path, Method.Delete);
        }

        /// <summary>
        /// Permanently removes a archived schema
        /// </summary>
        public void Purge(string objectType)
        {
            var path = $"/crm/v3/schemas/{objectType}/purge";
            this.client.Execute(path, Method.Delete);
        }
    }
}