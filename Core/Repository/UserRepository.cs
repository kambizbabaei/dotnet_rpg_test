
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cls.majvacore.infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IRepository;
using pr.Data;
using pr.Models;

namespace pr.Core.Repository
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        private DbSet<User> dbset;

        public UserRepository(DataContext Db) : base(Db)
        {
            dbset = Db.Users;
        }


        public async Task<User> findByUsernameAsync(string username)
        {
            try
            {
                User user = await dbset.FirstOrDefaultAsync(x => x.username.ToLower().Equals(username.ToLower()));
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> Upsert(User entity)
        {
            try
            {
                User existing = await this.GetByIdAsync(entity.Id);
                if (existing != null)
                {
                    existing.username = entity.username;
                    return true;
                }
                await this.InsertAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
