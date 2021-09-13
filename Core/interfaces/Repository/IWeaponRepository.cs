using System.Threading.Tasks;
using cls.majvacore.infra.Repository.Base;
using pr.Models;

namespace pr.Core.interfaces.Repository
{
    public interface IWeaponRepository : IGenericRepository<Weapon, int>
    {
        Task<bool> Upsert(Weapon entity);
    }
}
