# HubSpot-Sharp
A c# api library for the hubspot crm and other api endpoints.

This library was made because the most up to date library i could find for hubspot [Hubspot.NET](https://github.com/hubspot-net/HubSpot.NET) was too outdated and limited for my use case.
I will probably not update this library very regularly, but i'll try to handle any issues and pull requests.

### Caution
This library is largely untested, only crm functionality and other endpoints mentioned in the tests are guaranteed to work.
If you are planning to use this library please verify that the endpoints you want to use work.

### Setup
To use the library, add it as a project dependency (i might set up nuget later).
#### Authentication
To authenticate, create an AuthenticationApi and exchange for an access token or use a private access token.
##### Using oauth
```csharp
var auth = new AuthenticationApi();

GrantRequestOptions grantRequest = new()
{
    GrantType = GrantType.RefreshToken,
    ClientId = "client id",
    ClientSecret = "client secret",
    RedirectUri = "The redirect uri that was used when authenticating the application",
    RefreshToken = "refresh token obtained when authentication the application"
};

var authResponse = await auth.ExchangeTokens(grantRequest);

HubSpotToken token = new()
{
    AccessToken = authResponse.AccessToken,

    // The access token is the only field actually used, these fields are to handle future refreshing
    ExpiresAt = DateTime.Now.AddSeconds(authResponse.ExpiresIn),
    RefreshToken = authResponse.RefreshToken
};

// At this point you could set up OAuthTokenRefresher to automatically refresh the token.

HubSpotApi api = new(token);
// Now you can make api calls.
```
##### Using a private app
```csharp
HubSpotToken token = new()
{
    AccessToken = "your private access token"
};

HubSpotClient client = new(token);
// Now you can make api calls.
```
Note that the HubSpotClient will NOT automatically perform any token exchanges, refreshing access tokens is completely up to the user.
You can use the OAuthTokenRefresher class to automatically refresh the access token when you are using OAuth, or write a custom solution to handle this.

### Using custom crm fields
The library supports using custom crm object fields as well as completely custom crm objects.
To use custom fields create a child class of the crm object you want.
```csharp
[DataContract]
public class ExtendedCompany : Company
{
    // Setting the datamember's name is not required if it matches the field id in hubspot (in camelcase) already.
    [DataMember(Name = "The field's id in hubspot")]
    public string customField { get; set; }
    
    // Date fields are supported
    [DataMember]
    public DateTime? dateField { get; set; }

    // enumeration type fields (like multiple checkboxes) are supported with the HubSpotEnumeration attribute
    [DataMember]
    [HubSpotEnumeration]
    public IList<string> enumerationField { get; set; }
    
    // using the DeserializeOnly property will make a field never get sent back to hubspot, making it read only.
    [DataMember]
    [DeserializeOnly]
    public string readOnlyField { get; set; }
}
```
You can then use this object as such:
```csharp
IList<ExtendedCompany> company = (await Api.Crm.Company.List<ExtendedCompany>()).GetResults();
```

### Known issues
Getting private access token information currently return outdated information, or a 404 exception on newly created PAT's
