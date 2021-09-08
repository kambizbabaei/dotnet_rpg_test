using System.Collections.Generic;
using System.Threading.Tasks;
using pr.models;
using pr.Models;

namespace pr.services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        public Task<ServiceResponse<Character>> AddWeaponToCharacter()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<Weapon>>> AllWeapons()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<Character>> RemoveWeaponFromCharacter()
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<Weapon>>> UnusedWeapons()
        {
            throw new System.NotImplementedException();
        }
    }
}