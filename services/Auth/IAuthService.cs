using System.Threading.Tasks;
using pr.Models;

namespace pr.services.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<bool>> UserExist(string username);
        Task<ServiceResponse<string>> UnRegister(string username, string password);
    }
}