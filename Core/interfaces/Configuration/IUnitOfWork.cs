using System.Threading.Tasks;
using pr.Core.interfaces.IRepository;

namespace pr.Core.interfaces.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICharacterRepository Characters { get; }
        Task Complete();
    }
}