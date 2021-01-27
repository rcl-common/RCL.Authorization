using System.Threading.Tasks;

namespace RCL.Authorization.Core
{
    public interface IAuthClientOptionsProvider
    {
        Task<AuthClientOptions> GetClientOptionsAsync();
    }
}
