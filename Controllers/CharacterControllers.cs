using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Dtos.Character;
using dotnet.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;



namespace dotnet.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterControllers : ControllerBase{

        private readonly ICharacterService _characterService;
        public CharacterControllers(ICharacterService characterService){
            _characterService = characterService;
        }
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1, Name = "Mie"},
            new Character{Id = 2, Name = "Phuc"}
        };

        // private static List<Character> characters2 = new List<Character>{
        //     new Character(),
        //     new Character{Id = 2, Name = "Phuc"}
        // };

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get(){
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id){
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id){
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter){
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
         
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter) {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if (response.Data == null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}