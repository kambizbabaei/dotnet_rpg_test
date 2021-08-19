using System.Collections.Generic;
using System.Threading.Tasks;
using pr.models;

namespace pr.services.CharacterService
{
    public interface ICharacterService
    {

        Task<List<Character>> getAllCharacters();
        Task<Character> addCharacter(Character character);
        Task<Character> getFirst();
        Task<Character> Get(int? id);

    }
}