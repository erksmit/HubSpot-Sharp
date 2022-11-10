namespace HubSpot_Sharp.Custom
{
    using HubSpot_Sharp;

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
        /// <returns>A <see cref="CustomSchemaResponse" /> with information about the created schema.</returns>
        public CustomSchemaResponse Create(CustomObjectSchema schema)
        {
            return client.Execute<CustomSchemaResponse>("/crm/v3/schemas", Method.Post, schema);
        }

        /// <summary>
        /// Returns an existing object schema.
        /// </summary>
        public T Get<T>(string objectType)
            where T : HubSpotBaseModel, ICustomHubSpotObject, new()
        {
            var path = "/crm/v3/schemas/" + objectType;
            return client.Execute<T>(path, Method.Get);
        }

        public SchemaListResult GetAll()
        {
            return client.Execute<SchemaListResult>("/crm/v3/schemas", Method.Get);
        }

        /// <summary>
        /// Update the details for an existing object schema.
        /// </summary>
        public CustomSchemaResponse Update(CustomObjectSchema schema, string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            return client.Execute<CustomSchemaResponse>(path, Method.Patch, schema);
        }

        /// <summary>
        /// Deletes a schema. Any existing records of this schema must be deleted first. Otherwise this call will fail.
        /// </summary>
        public void Archive(string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            client.Execute(path, Method.Delete);
        }

        /// <summary>
        /// Permanently removes a archived schema
        /// </summary>
        public void Purge(string objectType)
        {
            var path = $"/crm/v3/schemas/{objectType}/purge";
            client.Execute(path, Method.Delete);
        }
    }
}