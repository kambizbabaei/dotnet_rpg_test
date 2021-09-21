using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pr.dto.Weapon;
using pr.Models;
using pr.services.StoreService;

namespace pr.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;

        }

        [HttpPost("AddWeapon")]
        public async Task<ServiceResponse<getWeaponDto>> addWeapon(addWeaponDto weapon)
        {
            return null;
        }

        [HttpPost("getWeapon/{id}")]
        public async Task<ServiceResponse<getWeaponDto>> getWeapon(int id)
        {
            return null;
        }

        [HttpGet("GetAllWeapon")]
        public async Task<ServiceResponse<List<getWeaponDto>>> getAllWeapon()
        {
            return null;
        }

        [HttpGet("PurchaseWeapon/{weaponId}")]
        public async Task<ServiceResponse<getWeaponDto>> purchaseWeapon(int weaponId)
        {
            ServiceResponse<getWeaponDto> response = null;
            int UserId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            await storeService.PurchaseWeapon(weaponId, UserId);


            return null;
        }

        [HttpDelete("removeWeapon/{id}")]
        public async Task<ServiceResponse<getWeaponDto>> removeWeapon()
        {
            return null;
        }
    }
}
