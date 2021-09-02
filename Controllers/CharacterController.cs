using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pr.dto.Character;
using pr.models;
using pr.services.CharacterService;

namespace pr.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {

        public readonly ICharacterService CharacterService;

        public CharacterController(ICharacterService characterService)
        {
            this.CharacterService = characterService;
        }

        [HttpGet("GetFirst")]
        public async Task<IActionResult> GetFirst()
        {
            int UserId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            return Ok(await this.CharacterService.getFirst(UserId));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            int UserId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            return Ok(await this.CharacterService.getAllCharacters(UserId));
        }



        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int id)
        {
            int UserId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);

            if (((await this.CharacterService.getAllCharacters(UserId)).Data.Count()) - 1 < id)
            {
                return NotFound();
            }
            return Ok(await this.CharacterService.Get(UserId, id));
        }
        [HttpPost("addcharacter")]
        public async Task<IActionResult> addCharacter(AddCharacterDto character)
        {
            int UserId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            return Ok(await this.CharacterService.addCharacter(UserId, character));
        }

        [HttpPut("update")]
        public async Task<IActionResult> updateCharacter(UpdateCharacterDto character)
        {
            int UserId = int.Parse((User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)).Value);
            return Ok(await this.CharacterService.UpdateCharacter(UserId, character));
        }

        // todo implenet delete character
    }
}