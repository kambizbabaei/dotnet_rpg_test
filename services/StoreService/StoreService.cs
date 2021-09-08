using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using pr.Core.interfaces.IConfiguration;
using pr.Core.Repository;
using pr.dto.Weapon;
using pr.Models;

namespace pr.services.StoreService
{
    public class StoreService : IStoreService
    {
        public readonly IMapper mapper;
        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this.WeaponRepository = UnitOfWork.Weapons;
            this.mapper = mapper;
        }
        public IUnitOfWork UnitOfWork { get; }
        public WeaponRepository WeaponRepository { get; }
        // public UserRepository UserRepository { get; }

        public async Task<ServiceResponse<getWeaponDto>> AddWeapon(addWeaponDto weapon)
        {
            ServiceResponse<getWeaponDto> response = new ServiceResponse<getWeaponDto>();
            Weapon weapon_ = mapper.Map<Weapon>(weapon);
            if (await WeaponRepository.Add(weapon_))
            {
                response.Data = mapper.Map<getWeaponDto>(weapon_);
                response.isSuccessful = true;
                response.Message = "weapon added successfully";
                return response;
            }
            response.Data = null;
            response.isSuccessful = false;
            response.Message = "request failed";
            return response;

        }

        public async Task<ServiceResponse<List<getWeaponDto>>> AllWeapons()
        {
            ServiceResponse<List<getWeaponDto>> response = new ServiceResponse<List<getWeaponDto>>();
            List<getWeaponDto> weapons = (await WeaponRepository.All()).Select(w => mapper.Map<getWeaponDto>(w)).ToList();
            response.Data = weapons;
            return response;

        }

        public Task<ServiceResponse<getWeaponDto>> PurchaseWeapon(int weaponId, int userid)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> RemoveWeapon(int weaponId)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            if (await WeaponRepository.Delete(weaponId))
            {
                response.Data = true;
                response.isSuccessful = true;
                response.Message = "weapon removed successfully";
                return response;
            }
            response.Data = false;
            response.isSuccessful = false;
            response.Message = "request failed";
            return response;

        }
    }
}