using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pr.Core.interfaces.IRepository;
using pr.Data;
using pr.models;

namespace pr.Core.Repository
{
    public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(DataContext Db, ILogger logger, DbSet<Character> dbset) : base(Db, logger, dbset)
        {
        }

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

        public override async Task<bool> Upsert(Character entity)
        {
            try
            {
                Character existing = await this.Find(entity.Id);
                if (existing != null)
                {
                    existing.power = entity.power;
                    existing.defense = entity.defense;
                    existing.hitPoints = entity.hitPoints;
                    existing.intelligence = entity.intelligence;
                    existing.name = entity.name;
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