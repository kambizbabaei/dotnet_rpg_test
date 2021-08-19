using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetFirst()
        {
            return Ok(this.CharacterService.getFirst());
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(this.CharacterService.getAllCharacters());
        }



        //has problem
        [HttpGet("{id?}")]
        public IActionResult Get(int? id)
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }
            else if (this.CharacterService.getAllCharacters().Count - 1 < id)
            {
                return NotFound();
            }
            return Ok(this.CharacterService.Get(id));

        }
        // has problem
        [HttpPost]
        public IActionResult addCharacter(Character character)
        {
            return Ok(this.CharacterService.addCharacter(character));
        }
    }
}