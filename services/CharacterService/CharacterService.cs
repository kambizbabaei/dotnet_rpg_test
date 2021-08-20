using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pr.dto.Character;
using pr.models;
using pr.Models;
using pr.services.CharacterService;

namespace pr.services.CharachterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character(){
                name = "gandolf",
                characterClass = RpgClass.wizard,
                id = 1
            },
            new Character(){
                name = "gollum",
                power = 150,
                defense = 50,
                characterClass = RpgClass.troll,
                id = 2
            }
        };


        public async Task<ServiceResponse<GetCharacterDto>> addCharacter(AddCharacterDto character)
        {
            character.id = characters.Count;
            characters.Add(character);
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = character;
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> Get(int? id)
        {
            Character? character = characters.FirstOrDefault(c => c.id == id);
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            if (character.Equals(null))
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "request failed;";
                return response;
            }
            response.Data = character;
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = characters;
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> getFirst()
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = characters[0];
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        Task<ServiceResponse<AddCharacterDto>> ICharacterService.addCharacter(AddCharacterDto character)
        {
            throw new System.NotImplementedException();
        }
    }
}