using System.Threading.Tasks;

namespace RCL.Authorization.Core
{
    public interface IAuthTokenService
    {
        Task<AuthToken> GetAuthTokenAsync(string resource);
    } 
}
