using System.Threading.Tasks;
using cls.majvacore.infra.Repository.DataAccess.UOW;
using pr.Core.Repository;

namespace pr.Core.interfaces.IConfiguration
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        UserRepository Users { get; }
        CharacterRepository Characters { get; }
        Task Complete();
    }
}