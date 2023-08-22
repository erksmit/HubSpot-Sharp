// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssociationSchemaApi.cs" company="">
//   
// </copyright>
// <summary>
//   The association schema api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Associations.Schema
{
    /// <summary>
    /// The association schema api.
    /// </summary>
    public class AssociationSchemaApi
    {
        /// <summary>
        /// The HubSpot client to make requests with.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationSchemaApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public AssociationSchemaApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Reads all defined associations for a pair of objects.
        /// </summary>
        /// <param name="fromObjectType">
        /// The type id of a hubspot object.
        /// </param>
        /// <param name="toObjectType">
        /// The type id of the other hubspot object.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> containing a list of defined associations.
        /// </returns>
        public async Task<IList<AssociationType>> Read(string fromObjectType, string toObjectType)
        {
            var path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/labels";
            var results = await client.Execute<ListResult<AssociationType>>(path);
            return results.Results;
        }

        /// <inheritdoc cref="Read(string, string)"/>
        /// <typeparam name="TFromHubType">
        /// A hubspot object type.
        /// </typeparam>
        /// <typeparam name="TToHubType">
        /// A hubspot object type.
        /// </typeparam>
        public async Task<IList<AssociationType>> Read<TFromHubType, TToHubType>()
            where TFromHubType : HubSpotObject where TToHubType : HubSpotObject
        {
            var fromId = AssociationIdAttribute.GetId<TFromHubType>();
            var toId = AssociationIdAttribute.GetId<TToHubType>();
            return await Read(fromId, toId);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="schema">
        /// The schema with the association type information.
        /// </param>
        /// <param name="fromObjectType">
        /// The type id of a hubspot object.
        /// </param>
        /// <param name="toObjectType">
        /// The type id of the other hubspot object.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<AssociationType> Create(
            CreateAssociationSchemaOptions schema,
            string fromObjectType,
            string toObjectType)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/labels";
            var results = await client.Execute<ListResult<AssociationType>>(path, HttpMethod.Post, schema);
            return results.Results.First();
        }

        /// <inheritdoc cref="Create(CreateAssociationSchemaOptions, string, string)"/>
        /// <typeparam name="TFromHubType">
        /// A hubspot object type.
        /// </typeparam>
        /// <typeparam name="TToHubType">
        /// A hubspot object type.
        /// </typeparam>
        public async Task<AssociationType> Create<TFromHubType, TToHubType>(CreateAssociationSchemaOptions schema)
            where TFromHubType : HubSpotObject where TToHubType : HubSpotObject
        {
            var fromId = AssociationIdAttribute.GetId<TFromHubType>();
            var toId = AssociationIdAttribute.GetId<TToHubType>();
            return await Create(schema, fromId, toId);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="type">
        /// The schema.
        /// </param>
        /// <param name="fromObjectType">
        /// The type id of a hubspot object.
        /// </param>
        /// <param name="toObjectType">
        /// The type id of the other hubspot object.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> that completes when the request has finished.
        /// </returns>
        public async Task Update(AssociationType type, string fromObjectType, string toObjectType)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/labels";
            await client.Execute(path, HttpMethod.Put, type);
        }

        /// <inheritdoc cref="Update(AssociationType, string, string)"/>
        /// <typeparam name="TFromHubType">
        /// A hubspot object type.
        /// </typeparam>
        /// <typeparam name="TToHubType">
        /// A hubspot object type.
        /// </typeparam>
        public async Task Update<TFromHubType, TToHubType>(AssociationType type)
            where TFromHubType : HubSpotObject where TToHubType : HubSpotObject
        {
            var fromId = AssociationIdAttribute.GetId<TFromHubType>();
            var toId = AssociationIdAttribute.GetId<TToHubType>();
            await Update(type, fromId, toId);
        }

        /// <summary>
        /// Deletes an association Type.
        /// </summary>
        /// <param name="associationTypeId">
        /// The type id of the association.
        /// </param>
        /// <param name="fromObjectType">
        /// The type id of a hubspot object.
        /// </param>
        /// <param name="toObjectType">
        /// The type id of the other hubspot object.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> that finishes when the request is completed.
        /// </returns>
        public async Task Delete(int associationTypeId, string fromObjectType, string toObjectType)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/labels/{associationTypeId}";
            await client.Execute(path, HttpMethod.Delete);
        }

        /// <inheritdoc cref="Delete(int, string, string)"/>
        /// <typeparam name="TFromHubType">
        /// A hubspot object type.
        /// </typeparam>
        /// <typeparam name="TToHubType">
        /// A hubspot object type.
        /// </typeparam>
        public async Task Delete<TFromHubType, TToHubType>(int associationTypeId)
            where TFromHubType : HubSpotObject where TToHubType : HubSpotObject
        {
            var fromId = AssociationIdAttribute.GetId<TFromHubType>();
            var toId = AssociationIdAttribute.GetId<TToHubType>();
            await Delete(associationTypeId, fromId, toId);
        }
    }
}