using System.Collections.Generic;
using System.Threading.Tasks;
using pr.dto.Weapon;
using pr.Models;

namespace pr.services.StoreService
{
    public interface IStoreService
    {
        Task<ServiceResponse<getWeaponDto>> AddWeapon(addWeaponDto weapon);
        Task<ServiceResponse<bool>> RemoveWeapon(int weaponId);
        Task<ServiceResponse<getWeaponDto>> PurchaseWeapon(int weaponId, int userid);
        Task<ServiceResponse<List<getWeaponDto>>> AllWeapons();

    }
}