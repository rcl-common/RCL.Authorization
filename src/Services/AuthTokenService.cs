using Microsoft.Extensions.Options;

namespace RCL.Authorization.Core
{
    public class AuthTokenService : AuthTokenServiceBase, IAuthTokenService
    {
        public AuthTokenService(IAuthClientOptionsProvider clientOptionsProvider,
            IAuthServerOptionsProvider serverOptionsProvider)
            : base(clientOptionsProvider,serverOptionsProvider)
        {
        }
    }
}
