using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pr.Core.interfaces.IConfiguration;
using pr.Core.Repository;
using pr.Data;
using pr.dto.Character;
using pr.models;
using pr.Models;

namespace pr.services.CharacterService
{
    public class CharacterServiceWithRepository : ICharacterService
    {

        public readonly IMapper mapper;
        public IUnitOfWork UnitOfWork { get; }
        public CharacterRepository CharacterRepository { get; }
        public UserRepository UserRepository { get; }

        public CharacterServiceWithRepository(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.CharacterRepository = unitOfWork.Characters;
            this.UserRepository = unitOfWork.Users;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<GetCharacterDto>> addCharacter(int userid, AddCharacterDto inCharacter)
        {

            Character character = mapper.Map<Character>(inCharacter);
            character.owner = await UserRepository.Find(userid);
            await CharacterRepository.Add(character);
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = mapper.Map<GetCharacterDto>(character);
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            await UnitOfWork.Complete();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> Get(int userid, int id)
        {
            Character character = (await CharacterRepository.Find(id));

            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            if (character is null)
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "request failed;";
                return response;
            }
            else if (character.owner.Id != userid)
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

            // response.Data = ((await Db.characters.ToListAsync()).Select(c => mapper.Map<GetCharacterDto>(c))).ToList();
            response.Data = (((await CharacterRepository.GetUsersCharacters(userid)).Select(c => mapper.Map<GetCharacterDto>(c))).ToList());
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> getFirst(int userid)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            response.Data = mapper.Map<GetCharacterDto>(((await CharacterRepository.GetUsersCharacters(userid)).OrderBy(c => c.Id).FirstOrDefault()));
            response.isSuccessful = true;
            response.Message = "request accomplished;";
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int userid, UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            Character character = await CharacterRepository.Find(updateCharacter.id);
            if (character == null)
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "character not found";
            }
            if (character.owner.Id != userid)
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "bad request";
            }

            bool isUpdated = await CharacterRepository.Upsert(character);
            if (isUpdated)
            {
                response.Data = mapper.Map<GetCharacterDto>(character);
                response.isSuccessful = true;
                response.Message = "character updated successfuly.";
            }
            else
            {
                response.Data = null;
                response.isSuccessful = false;
                response.Message = "something went wrong!";
            }
            await UnitOfWork.Complete();
            return response;
        }

        public async Task<ServiceResponse<Character>> DeleteCharacter(int userid, int id)
        {
            ServiceResponse<Character> serviceResponse = new ServiceResponse<Character>();
            if ((await CharacterRepository.Find(id)).owner.Id != userid)
            {
                serviceResponse.Data = null;
                serviceResponse.isSuccessful = false;
                serviceResponse.Message = "bad request";
            }
            bool isDeleted = await CharacterRepository.Delete(id);
            if (isDeleted)
            {
                serviceResponse.Data = null;
                serviceResponse.isSuccessful = true;
                serviceResponse.Message = "request compeleted successfuly";
            }
            else
            {
                serviceResponse.Data = null;
                serviceResponse.isSuccessful = false;
                serviceResponse.Message = "request failed";
            }
            await UnitOfWork.Complete();
            return serviceResponse;
        }
    }
}