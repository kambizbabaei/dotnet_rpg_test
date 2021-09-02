
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IRepository;
using pr.Data;
using pr.Models;

namespace pr.Core.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext Db, ILogger logger, DbSet<User> dbset) : base(Db, logger, dbset)
        {
        }

        public override async Task<bool> Upsert(User entity)
        {
            try
            {
                User existing = await this.Find(entity.Id);
                if (existing != null)
                {
                    existing.username = entity.username;
                    return true;
                }
                return await this.Add(entity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{Repo} upsert error", typeof(UserRepository));
                return false;
            }
        }
    }
}