using System.Threading.Tasks;
using cls.majvacore.infra.Repository.Base;
using pr.Models;

namespace pr.Core.interfaces.IRepository
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<User> findByUsernameAsync(string username);
        Task<bool> Upsert(User entity);
    }
}
