using System.Collections.Generic;
using System.Threading.Tasks;
using cls.majvacore.infra.Domain.Entities;
using cls.majvacore.infra.Repository.Base;
using pr.models;

namespace pr.Core.interfaces.IRepository
{
    public interface ICharacterRepository: IGenericRepository<Character, int>
    {
        public Task<IEnumerable<Character>> GetUsersCharacters(int userid);
        public Task<bool> Upsert(Character entity);
    }
}