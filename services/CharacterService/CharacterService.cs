using System.Collections.Generic;
using System.Linq;
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


        public Character addCharacter(Character character)
        {
            character.id = characters.Count;
            characters.Add(character);
            return character;
        }

        public Character Get(int? id)
        {
            Character? character = characters.FirstOrDefault(c => c.id == id);
            return character;
        }

        public List<Character> getAllCharacters()
        {
            return characters;
        }

        public Character getFirst()
        {
            return characters[0];
        }
    }
}