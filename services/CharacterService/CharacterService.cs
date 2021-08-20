using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<ServiceResponse<Character>> addCharacter(Character character)
        {
            character.id = characters.Count;
            characters.Add(character);
            ServiceResponse<Character> response = new ServiceResponse<Character>();
            response.Data = character;
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<Character>> Get(int? id)
        {
            Character? character = characters.FirstOrDefault(c => c.id == id);
            ServiceResponse<Character> response = new ServiceResponse<Character>();
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

        public async Task<ServiceResponse<List<Character>>> getAllCharacters()
        {
            ServiceResponse<List<Character>> response = new ServiceResponse<List<Character>>();
            response.Data = characters;
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<Character>> getFirst()
        {
            ServiceResponse<Character> response = new ServiceResponse<Character>();
            response.Data = characters[0];
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }
    }
}