using System.Collections.Generic;
using System.Threading.Tasks;
using pr.dto.Character;
using pr.models;
using pr.Models;

namespace pr.services.CharacterService
{
    public interface ICharacterService
    {

        Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters(int userid);
        Task<ServiceResponse<GetCharacterDto>> addCharacter(int userid, AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> getFirst(int userid);
        Task<ServiceResponse<GetCharacterDto>> Get(int userid, int id);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int userid, UpdateCharacterDto updateCharacter);
        Task<ServiceResponse<Character>> DeleteCharacter(int userid, int id);
    }
}