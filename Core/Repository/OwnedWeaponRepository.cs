using cls.majvacore.infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.Repository;
using pr.Data;
using pr.Models;

namespace pr.Core.Repository
{
    public class OwnedWeaponRepository : Repository<OwnedWeapon, int>, IOwnedWeaponRepository
    {
        public OwnedWeaponRepository(DataContext Db) : base(Db)
        {
        }
    }
}