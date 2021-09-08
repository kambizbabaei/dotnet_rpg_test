using System.Collections.Generic;
using System.Threading.Tasks;
using pr.models;
using pr.Models;

namespace pr.services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<Character>> AddWeaponToCharacter();
        Task<ServiceResponse<Character>> RemoveWeaponFromCharacter();
        Task<ServiceResponse<List<Weapon>>> AllWeapons();
        Task<ServiceResponse<List<Weapon>>> UnusedWeapons();

    }
}