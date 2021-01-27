using System.Threading.Tasks;

namespace RCL.Authorization.Core
{
    public interface IAuthServerOptionsProvider
    {
        Task<AuthServerOptions> GetServiceOptionsAsync(string resource);
    }
}
