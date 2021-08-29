using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pr.dto.Character;
using pr.models;
using pr.Models;
using pr.services.CharacterService;

namespace pr.services.CharachterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper mapper;
        public CharacterService(IMapper mapper)
        {
            this.mapper = mapper;

        }

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


        public async Task<ServiceResponse<GetCharacterDto>> addCharacter(int userid, AddCharacterDto inCharacter)
        {
            Character character = mapper.Map<Character>(inCharacter);
            character.id = characters.Count;
            characters.Add(character);
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = mapper.Map<GetCharacterDto>(character);
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> Get(int userid, int? id)
        {
            Character character = characters.FirstOrDefault(c => c.id == id);
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            if (character is null)
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "request failed;";
                return response;
            }
            response.Data = mapper.Map<GetCharacterDto>(character);
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters(int userid)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = (characters.Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> getFirst(int userid)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = mapper.Map<GetCharacterDto>(characters[0]);
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int userid, UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            Character character = characters.FirstOrDefault(c => c.id == updateCharacter.id);
            try
            {
                character.name = updateCharacter.name;
                character.characterClass = updateCharacter.characterClass;
                character.defense = updateCharacter.defense;
                character.hitPoints = updateCharacter.hitPoints;
                character.intelligence = updateCharacter.intelligence;
                character.power = updateCharacter.power;

                response.Data = mapper.Map<GetCharacterDto>(character);
                response.isSuccessful = true;
                response.Message = "character updated successfuly.";
                return response;
            }
            catch
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "request failed; character not found!";
                return response;
            }
        }

        public async Task<ServiceResponse<Character>> DeleteCharacter(int userid, int? id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            Character character = characters.FirstOrDefault(c => c.id == id);
            try
            {
                characters.Remove(character);
                serviceResponse.Data = null;
                serviceResponse.isSuccessful = true;
                serviceResponse.Message = "request compeleted successfuly";
                return serviceResponse;
            }
            catch
            {
                serviceResponse.Data = null;
                serviceResponse.isSuccessful = false;
                serviceResponse.Message = "request failed";
                return serviceResponse;
            }
        }
    }
}