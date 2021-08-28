using System.Threading.Tasks;
using pr.Data;
using pr.Models;

namespace pr.services.Auth
{
    public class AuthService : IAuthService
    {
        public readonly DataContext Database;
        public AuthService(DataContext database)
        {
            this.Database = database;

        }
        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }
        public Task<ServiceResponse<int>> Register(User user, string password)
        {
            throw new System.NotImplementedException();
        }
        public Task<ServiceResponse<string>> UnRegister(string username, string password)
        {
            throw new System.NotImplementedException();
        }
        public Task<ServiceResponse<bool>> UserExist(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}