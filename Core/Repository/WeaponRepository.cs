using System.Threading.Tasks;
using cls.majvacore.infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.Repository;
using pr.Data;
using pr.Models;

namespace pr.Core.Repository
{
    public class WeaponRepository : Repository<Weapon, int>, IWeaponRepository
    {
        public WeaponRepository(DataContext Db) : base(Db)
        {
        }

        public Task<bool> Upsert(Weapon entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
