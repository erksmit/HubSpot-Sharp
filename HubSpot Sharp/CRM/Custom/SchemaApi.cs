// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SchemaApi.cs" company="">
//   
// </copyright>
// <summary>
//   The schema api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Custom
{
    /// <summary>
    /// Contains functions for interacting with custom schema endpoints.
    /// </summary>
    public class SchemaApi
    {
        /// <summary>
        /// The client to make requests with.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaApi"/> class.
        /// The schema api.
        /// </summary>
        /// <param name="client">
        /// The HubSpot client to make requests with.
        /// </param>
        public SchemaApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Creates a custom object schema using the provided schema.
        /// </summary>
        /// <param name="schema">
        /// The schema to create.
        /// </param>
        /// <returns>
        /// A <see cref="SchemaInformation"/> with information about the created schema.
        /// </returns>
        public SchemaInformation Create(ObjectSchema schema)
        {
            return client.Execute<SchemaInformation>("/crm/v3/schemas", HttpMethod.Post, schema);
        }

        /// <summary>
        /// Returns an existing schema using the Fully qualified name or object type ID of your schema.
        /// </summary>
        /// <param name="objectType">
        /// The objectId or fully qualified name of the schema.
        /// </param>
        /// <returns>
        /// The schema object.
        /// </returns>
        public SchemaInformation Get(string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            return client.Execute<SchemaInformation>(path);
        }

        /// <summary>
        /// Get all object schemas.
        /// </summary>
        /// <returns>
        /// A list containing all object schemas, it will never have paging.
        /// </returns>
        public ListResult<SchemaInformation> GetAll()
        {
            return client.Execute<ListResult<SchemaInformation>>("/crm/v3/schemas");
        }

        /// <summary>
        /// Update the details for an existing object schema.
        /// </summary>
        /// <param name="schema">
        /// The schema to update.
        /// </param>
        /// <param name="objectType">
        /// The object type id of the existing schema.
        /// </param>
        /// <returns>
        /// The updated schema.
        /// </returns>
        public SchemaInformation Update(ObjectSchema schema, string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            return client.Execute<SchemaInformation>(path, HttpMethod.Patch, schema);
        }

        /// <summary>
        /// Deletes a schema. Any existing records of this schema must be deleted first. Otherwise this call will fail.
        /// </summary>
        /// <param name="objectType">
        /// The object type id for the schema.
        /// </param>
        public void Archive(string objectType)
        {
            var path = "/crm/v3/schemas/" + objectType;
            client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// Permanently removes a archived schema.
        /// </summary>
        /// <param name="objectType">
        /// The object type id for the schema.
        /// </param>
        public void Purge(string objectType)
        {
            var path = $"/crm/v3/schemas/{objectType}/purge";
            client.Execute(path, HttpMethod.Delete);
        }
    }
}