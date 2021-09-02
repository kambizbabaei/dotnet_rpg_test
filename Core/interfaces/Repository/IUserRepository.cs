using System.Threading.Tasks;
using pr.Models;

namespace pr.Core.interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> findByUsernameAsync(string username);
    }
}