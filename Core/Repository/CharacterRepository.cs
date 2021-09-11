using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cls.majvacore.infra.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IRepository;
using pr.Data;
using pr.models;

namespace pr.Core.Repository
{
    public class CharacterRepository : Repository<Character, int>, ICharacterRepository
    {
        public CharacterRepository(DataContext Db/*, ILogger logger, DbSet<Character> dbset*/) : base(Db)
        {
            /*Logger = logger;
            this.dbset = dbset;*/
        }

        public ILogger Logger { get; }
        public DbSet<Character> dbset { get; }
        
        public async Task<IEnumerable<Character>> GetUsersCharacters(int userid)
        {
            try
            {
                return dbset.Where(x => x.owner.Id == userid);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{Repo} GetUsersCharacters error", typeof(UserRepository));
                return new List<Character>();
            }
        }

        public async Task<bool> Upsert(Character entity)
        {
            try
            {
                Character existing = await this.GetByIdAsync(entity.Id);
                if (existing != null)
                {
                    existing.power = entity.power;
                    existing.defense = entity.defense;
                    existing.hitPoints = entity.hitPoints;
                    existing.intelligence = entity.intelligence;
                    existing.name = entity.name;
                    await this.UpdateAsync(existing);
                    return true;
                }
                await this.InsertAsync(entity);
                return (true);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{Repo} upsert error", typeof(UserRepository));
                return false;
            }
        }

    }
}