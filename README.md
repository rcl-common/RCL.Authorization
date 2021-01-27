# RCL.Authorization

A library to generate JWT Access Tokens using an Azure Active Directory application to access Azure resources.

## Usage

Ceate a new Application Registration using Azure Active Directory

Add the credetails for the Application registration in the User Secrets

```json

{
  "Auth:client_id": "1234-4567-8967",
  "Auth:client_secret": "pwd1234_abc~",
  "Auth:tenantId": "246-81012-141618"
}

```

Inject the service 

```csharp

  services.AddAuthTokenService(options => Configuration.Bind("Auth",options));

```

Use the service ass follows

```csharp
string resource = "https://management.core.windows.net";
AuthToken authToken = await _authTokenService.GetAuthTokenAsync(resource);
string accessToken = authToken.access_token;
```
