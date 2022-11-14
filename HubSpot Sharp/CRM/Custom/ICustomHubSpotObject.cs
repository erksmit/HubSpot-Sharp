namespace HubSpot_Sharp.CRM.Custom
{
    public interface ICustomHubSpotObject
    {
        string ObjectId => ObjectIdStatic;
        /// <summary>
        /// The custom id used to identify the object type, you can get this by calling the <see cref="SchemaApi"/>'s GetAll function and reading the response
        /// </summary>
        static string ObjectIdStatic { get; set; }
    }
}