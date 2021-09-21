using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using pr.Core.interfaces.IConfiguration;
using pr.Core.Repository;
using pr.dto.Weapon;
using pr.Models;

namespace pr.services.StoreService
{
    public class StoreService : IStoreService
    {
        public readonly IMapper mapper;
        public IUnitOfWork UnitOfWork { get; }

        public StoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.UnitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ServiceResponse<getWeaponDto>> AddWeapon(addWeaponDto weapon)
        {
            ServiceResponse<getWeaponDto> response = new ServiceResponse<getWeaponDto>();
            Weapon weapon_ = mapper.Map<Weapon>(weapon);
            await UnitOfWork.Weapons.InsertAsync(weapon_);
            if (true)
            {
                response.Data = mapper.Map<getWeaponDto>(weapon_);
                response.isSuccessful = true;
                response.Message = "weapon added successfully";
                await UnitOfWork.Complete();
                return response;
            }
            // response.Data = null;
            // response.isSuccessful = false;
            // response.Message = "request failed";
            // return response;

        }

        public async Task<ServiceResponse<List<getWeaponDto>>> AllWeapons()
        {
            ServiceResponse<List<getWeaponDto>> response = new ServiceResponse<List<getWeaponDto>>();
            List<getWeaponDto> weapons = await (UnitOfWork.Weapons.GetAll()).Select(w => mapper.Map<getWeaponDto>(w)).ToListAsync();
            response.Data = weapons;
            return response;

        }

        public async Task<ServiceResponse<OwnedWeapon>> PurchaseWeapon(int weaponId, int userid)
        {
            // todo : add userWeaponDto
            OwnedWeapon weapon = new OwnedWeapon();
            weapon.user = await UnitOfWork.Users.GetByIdAsync(userid);
            weapon.weapon = await UnitOfWork.Weapons.GetByIdAsync(weaponId);
            weapon.Health = 100;
            await UnitOfWork.UserWeapons.InsertAsync(weapon);
            ServiceResponse<OwnedWeapon> response = new ServiceResponse<OwnedWeapon>();
            response.Data = weapon;
            response.isSuccessful = true;
            response.Message = "weapon purchased successful";
            return response;

        }

        public async Task<ServiceResponse<bool>> RemoveWeapon(int weaponId)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            await UnitOfWork.Weapons.DeleteAsync(weaponId);
            if (true)
            {
                response.Data = true;
                response.isSuccessful = true;
                response.Message = "weapon removed successfully";
                await UnitOfWork.Complete();
                return response;
            }
            // response.Data = false;
            // response.isSuccessful = false;
            // response.Message = "request failed";
            // return response;

        }

        public Task<ServiceResponse<getWeaponDto>> getWeapon(int waeponId)
        {
            throw new System.NotImplementedException();
        }
    }
}
