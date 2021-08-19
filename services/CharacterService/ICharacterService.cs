using System.Collections.Generic;
using pr.models;

namespace pr.services.CharacterService
{
    public interface ICharacterService
    {

        List<Character> getAllCharacters();
        Character addCharacter(Character character);
        Character getFirst();
        Character Get(int? id);

    }
}