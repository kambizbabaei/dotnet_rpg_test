using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pr.models;
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


        public async Task<Character> addCharacter(Character character)
        {
            character.id = characters.Count;
            characters.Add(character);
            return character;
        }

        public async Task<Character> Get(int? id)
        {
            Character? character = characters.FirstOrDefault(c => c.id == id);
            return character;
        }

        public async Task<List<Character>> getAllCharacters()
        {
            return characters;
        }

        public async Task<Character> getFirst()
        {
            return characters[0];
        }
    }
}