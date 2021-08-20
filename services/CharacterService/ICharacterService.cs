using System.Collections.Generic;
using System.Threading.Tasks;
using pr.dto.Character;
using pr.models;
using pr.Models;

namespace pr.services.CharacterService
{
    public interface ICharacterService
    {

        Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> addCharacter(AddCharacterDto character);
        Task<ServiceResponse<GetCharacterDto>> getFirst();
        Task<ServiceResponse<GetCharacterDto>> Get(int? id);

    }
}