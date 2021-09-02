using System.Collections.Generic;
using System.Threading.Tasks;
using pr.models;

namespace pr.Core.interfaces.IRepository
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetUsersCharacters(int userid);
    }
}