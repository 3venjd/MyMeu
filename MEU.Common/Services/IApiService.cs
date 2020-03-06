using MEU.Common.Models;
using System.Threading.Tasks;

namespace MEU.Common.Services
{
    public interface IApiService
    {
        Task<Response<ClientResponse>> GetClientByEmailAsync(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, string email);
        Task<Response<TokenResponse>> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<bool> CheckConnectionAsync(string url);
    }
}