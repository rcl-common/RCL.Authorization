using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace RCL.Authorization.Core
{
    public class ClientOptionsProvider : IAuthClientOptionsProvider
    {
        private readonly IOptions<AuthOptions> _options;

        public ClientOptionsProvider(IOptions<AuthOptions> options)
        {
            _options = options;
        }

        public Task<AuthClientOptions> GetClientOptionsAsync()
        {
            return Task.Run(() => new AuthClientOptions
            {
                client_id = _options.Value.client_id,
                client_secret = _options.Value.client_secret,
                tenantId = _options.Value.tenantId
            });
        }
    }
}
