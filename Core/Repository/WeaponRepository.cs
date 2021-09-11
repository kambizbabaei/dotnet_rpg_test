using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.Repository;
using pr.Data;
using pr.Models;

namespace pr.Core.Repository
{
    public class WeaponRepository : GenericRepository<Weapon>, IWeaponRepository
    {
        public WeaponRepository(DataContext Db, ILogger logger, DbSet<Weapon> dbset) : base(Db, logger, dbset)
        {
        }

        public override async Task<bool> Upsert(Weapon entity)
        {
            return false;
        }
    }
}