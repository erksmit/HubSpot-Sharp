namespace HubSpot_Sharp.CRM.Property
{
    using HubSpot_Sharp.CRM.Custom;
    using HubSpot_Sharp.Intermediates;

    using RestSharp;

    public class PropertyApi
    {
        private readonly HubSpotClient client;
        public PropertyApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<PropertyInformation> GetAll(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return this.client.Execute<ListResult<PropertyInformation>>(path);
        }

        public PropertyInformation Create(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return this.client.Execute<PropertyInformation>(path, Method.Post, property);
        }

        public PropertyInformation Get(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            return this.client.Execute<PropertyInformation>(path);
        }

        public PropertyInformation Update(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}/{property.Name}";
            return this.client.Execute<PropertyInformation>(path, Method.Patch, property);
        }

        public void Archive(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }
        public void ArchiveBatch(string objectType, IList<string> inputs)
        {
            this.ArchiveBatch(objectType, new ListInputs<NameInput>(inputs.Select(i => new NameInput(i)).ToList()));
        }

        public BatchResult<PropertyInformation> CreateBatch(string objectType, ListInputs<ObjectProperty> properties)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/create";
            return this.client.Execute<BatchResult<PropertyInformation>>(path, Method.Post, properties);
        }

        public BatchResult<PropertyInformation> ReadBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/read";
            return this.client.Execute<BatchResult<PropertyInformation>>(path, Method.Post, inputs);
        }

        public ListResult<PropertyGroup> ReadGroups(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return this.client.Execute<ListResult<PropertyGroup>>(path);
        }

        public PropertyGroup CreateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return this.client.Execute<PropertyGroup>(path, Method.Post, group);
        }

        public PropertyGroup ReadGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            return this.client.Execute<PropertyGroup>(path);
        }

        public PropertyGroup UpdateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{group.Name}";
            return this.client.Execute<PropertyGroup>(path, Method.Patch, group);
        }

        public void DeleteGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            this.client.Execute(path, Method.Delete);
        }
    }
}
