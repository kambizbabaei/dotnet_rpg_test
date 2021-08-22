using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pr.Data;
using pr.dto.Character;
using pr.models;
using pr.Models;

namespace pr.services.CharacterService
{
    public class CharacterServiceWithDb : ICharacterService
    {
        public IMapper mapper { get; }
        public DataContext Db { get; }

        public CharacterServiceWithDb(IMapper mapper, DataContext db)
        {
            this.Db = db;
            this.mapper = mapper;

        }

        public async Task<ServiceResponse<GetCharacterDto>> addCharacter(AddCharacterDto inCharacter)
        {
            Character character = mapper.Map<Character>(inCharacter);
            await Db.characters.AddAsync(character);
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            await Db.SaveChangesAsync();
            response.Data = mapper.Map<GetCharacterDto>(character);
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> Get(int? id)
        {
            Character character = (await Db.characters.FirstOrDefaultAsync(c => c.id == id));
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

        public async Task<ServiceResponse<List<GetCharacterDto>>> getAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = ((await Db.characters.ToListAsync()).Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> getFirst()
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = mapper.Map<GetCharacterDto>((await Db.characters.FirstAsync()));
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            Character character = await Db.characters.FirstOrDefaultAsync(c => c.id == updateCharacter.id);
            try
            {
                character.name = updateCharacter.name;
                character.characterClass = updateCharacter.characterClass;
                character.defense = updateCharacter.defense;
                character.hitPoints = updateCharacter.hitPoints;
                character.intelligence = updateCharacter.intelligence;
                character.power = updateCharacter.power;
                Db.Update(character);
                await Db.SaveChangesAsync();
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

        public async Task<ServiceResponse<Character>> DeleteCharacter(int? id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            Character character = await Db.characters.FirstOrDefaultAsync(c => c.id == id);
            try
            {
                Db.characters.Remove(character);
                await Db.SaveChangesAsync();
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
