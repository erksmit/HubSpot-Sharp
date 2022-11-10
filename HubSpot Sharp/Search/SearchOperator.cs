namespace HubSpot_Sharp.Search
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum SearchOperator
    {
        /// <summary>
        /// Less than
        /// </summary>
        [EnumMember(Value = "LT")]
        LessThan,

        /// <summary>
        /// Less than or equal to
        /// </summary>
        [EnumMember(Value = "LTE")]
        LessThanOrEqual,

        /// <summary>
        /// Greater than
        /// </summary>
        [EnumMember(Value = "GT")]
        GreaterThan,

        /// <summary>
        /// Greater than or equal to
        /// </summary>
        [EnumMember(Value = "GTE")]
        GreaterThanOrEqual,

        /// <summary>
        /// Equal to
        /// </summary>
        [EnumMember(Value = "EQ")]
        EqualTo,

        /// <summary>
        /// Not equal to
        /// </summary>
        [EnumMember(Value = "NEQ")]
        NotEqualTo,

        /// <summary>
        /// Within the specified range. In your request, use key-value pairs to set highValue and value.
        /// </summary>
        [EnumMember(Value = "BETWEEN")]
        WithinRange,

        /// <summary>
        /// Included within the specified list
        /// </summary>
        [EnumMember(Value = "IN")]
        In,

        /// <summary>
        /// Not included within the specified list
        /// </summary>
        [EnumMember(Value = "NOT_IN")]
        NotIn,

        /// <summary>
        /// Has a value for the specified property
        /// </summary>
        [EnumMember(Value = "HAS_PROPERTY")]
        HasProperty,

        /// <summary>
        /// Doesn't have a value for the specified property
        /// </summary>
        [EnumMember(Value = "NOT_HAS_PROPERTY")]
        NotHasProperty,

        /// <summary>
        /// Contains a token. In your request, you can use wildcards (*) to complete a partial search. For example, use the value
        /// *@hubspot.com to retrieve contacts with a HubSpot email address.
        /// </summary>
        [EnumMember(Value = "CONTAINS_TOKEN")]
        ContainsToken,

        /// <summary>
        /// Doesn't contain a token
        /// </summary>
        [EnumMember(Value = "NOT_CONTAINS_TOKEN")]
        NotContainsToken
    }
}