// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyApi.cs" company="">
//   
// </copyright>
// <summary>
//   The property api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Property
{
    /// <summary>
    /// The property api.
    /// </summary>
    public class PropertyApi
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public PropertyApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<PropertyInformation>> GetAll(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return await client.Execute<ListResult<PropertyInformation>>(path);
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<PropertyInformation> Create(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return await client.Execute<PropertyInformation>(path, HttpMethod.Post, property);
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<PropertyInformation> Get(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            return await client.Execute<PropertyInformation>(path);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<PropertyInformation> Update(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}/{property.Name}";
            return await client.Execute<PropertyInformation>(path, HttpMethod.Patch, property);
        }

        /// <summary>
        /// The archive.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Archive(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            await client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// The archive batch.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="inputs">
        /// The inputs.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task ArchiveBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/archive";
            await client.Execute(path, HttpMethod.Post, inputs);
        }

        /// <summary>
        /// The archive batch.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="inputs">
        /// The inputs.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task ArchiveBatch(string objectType, IList<string> inputs)
        {
            await ArchiveBatch(objectType, new ListInputs<NameInput>(inputs.Select(i => new NameInput(i)).ToList()));
        }

        /// <summary>
        /// The create batch.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="properties">
        /// The properties.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<BatchResult<PropertyInformation>> CreateBatch(
            string objectType,
            ListInputs<ObjectProperty> properties)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/create";
            return await client.Execute<BatchResult<PropertyInformation>>(path, HttpMethod.Post, properties);
        }

        /// <summary>
        /// The read batch.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="inputs">
        /// The inputs.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<BatchResult<PropertyInformation>> ReadBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/read";
            return await client.Execute<BatchResult<PropertyInformation>>(path, HttpMethod.Post, inputs);
        }

        /// <summary>
        /// The read groups.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<PropertyGroup>> ReadGroups(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return await client.Execute<ListResult<PropertyGroup>>(path);
        }

        /// <summary>
        /// The create group.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="group">
        /// The group.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<PropertyGroup> CreateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return await client.Execute<PropertyGroup>(path, HttpMethod.Post, group);
        }

        /// <summary>
        /// The read group.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="groupName">
        /// The group name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<PropertyGroup> ReadGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            return await client.Execute<PropertyGroup>(path);
        }

        /// <summary>
        /// The update group.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="group">
        /// The group.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<PropertyGroup> UpdateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{group.Name}";
            return await client.Execute<PropertyGroup>(path, HttpMethod.Patch, group);
        }

        /// <summary>
        /// The delete group.
        /// </summary>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="groupName">
        /// The group name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            await client.Execute(path, HttpMethod.Delete);
        }
    }
}