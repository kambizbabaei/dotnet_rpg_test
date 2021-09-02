using System.Threading.Tasks;
using pr.Core.Repository;

namespace pr.Core.interfaces.IConfiguration
{
    public interface IUnitOfWork
    {
        UserRepository Users { get; }
        CharacterRepository Characters { get; }
        Task Complete();
    }
}