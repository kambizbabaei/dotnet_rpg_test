using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pr.models;
using pr.services.CharacterService;

namespace pr.Controllers
{
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
            return Ok(await this.CharacterService.getFirst());
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.CharacterService.getAllCharacters());
        }



        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            else if (((await this.CharacterService.getAllCharacters()).Data.Count()) - 1 < id)
            {
                return NotFound();
            }
            return Ok(await this.CharacterService.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> addCharacter(Character character)
        {
            return Ok(await this.CharacterService.addCharacter(character));
        }
    }
}