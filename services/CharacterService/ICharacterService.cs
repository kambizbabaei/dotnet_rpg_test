using System.Collections.Generic;
using System.Threading.Tasks;
using pr.models;
using pr.Models;

namespace pr.services.CharacterService
{
    public interface ICharacterService
    {

        Task<ServiceResponse<List<Character>>> getAllCharacters();
        Task<ServiceResponse<Character>> addCharacter(Character character);
        Task<ServiceResponse<Character>> getFirst();
        Task<ServiceResponse<Character>> Get(int? id);

    }
}