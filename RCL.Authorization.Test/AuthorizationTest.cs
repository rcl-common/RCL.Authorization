using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCL.Authorization.Core;
using System;
using System.Threading.Tasks;

namespace RCL.Authorization.Test
{
    [TestClass]
    public class AzureAuthorizationTest
    {
        [TestMethod]
        public async Task GetAuthTokenTest()
        {
            try
            {
                string resource = "https://management.core.windows.net";
                LocalAuthTokenService authTokenService = new LocalAuthTokenService();
                AuthToken authToken = await authTokenService.GetAuthTokenAsync(resource);
                Assert.AreNotEqual(string.Empty, authToken.access_token);
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                Assert.Fail();
            }
        }
    }

    public class LocalAuthTokenService : AuthTokenServiceBase, IAuthTokenService
    {
        public LocalAuthTokenService()
            : base (new ClientOptionsStaticProvider(), new ServiceOptionsStaticProvider())
        {
        }
    }

    public class ClientOptionsStaticProvider : IAuthClientOptionsProvider
    {
        private readonly IOptions<AuthOptions> _auth;

        public ClientOptionsStaticProvider()
        {
            _auth = (IOptions<AuthOptions>)DependencyResolver
            .ServiceProvider()
            .GetService(typeof(IOptions<AuthOptions>));
        }

        public async Task<AuthClientOptions> GetClientOptionsAsync()
        {
            return await Task.FromResult<AuthClientOptions>(GetStaticClientOptions());
        }

        public AuthClientOptions GetStaticClientOptions()
        {
            return new AuthClientOptions
            {
                client_id = _auth.Value.client_id,
                client_secret = _auth.Value.client_secret,
                tenantId = _auth.Value.tenantId
            };
        }
    }

    public class ServiceOptionsStaticProvider : IAuthServerOptionsProvider
    {
        public async Task<AuthServerOptions> GetServiceOptionsAsync(string resource)
        {
            return await Task.FromResult<AuthServerOptions>(GetStaticServiceOptions(resource));
        }

        public AuthServerOptions GetStaticServiceOptions(string resource)
        {
            return new AuthServerOptions
            {
                endpoint = $"https://login.microsoftonline.com/11cd9a7c-bc7c-4929-b9c2-2702c3b9b0e7/oauth2/token",
                grant_type = "client_credentials",
                resource = resource
            };
        }
    }
}
