using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.Repository;
using pr.Data;
using pr.Models;

namespace pr.Core.Repository
{
    public class OwnedWeaponRepository : GenericRepository<OwnedWeapon>, IOwnedWeaponRepository
    {
        public OwnedWeaponRepository(DataContext Db, ILogger logger, DbSet<OwnedWeapon> dbset) : base(Db, logger, dbset)
        {
        }
    }
}