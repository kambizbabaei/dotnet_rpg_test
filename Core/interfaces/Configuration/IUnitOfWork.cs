using System.Threading.Tasks;
using cls.majvacore.infra.Repository.DataAccess.UOW;
using pr.Core.interfaces.IRepository;
using pr.Core.Repository;

namespace pr.Core.interfaces.IConfiguration
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        IUserRepository Users { get; }
        ICharacterRepository Characters { get; }
        WeaponRepository Weapons { get; }
        OwnedWeaponRepository UserWeapons { get; }

        Task Complete();
    }
}
