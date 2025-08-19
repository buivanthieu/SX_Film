using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.Actors;
using WebBackend.Models;
using WebBackend.Services.Actors;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMapper _mapper;
        public ActorsController(IActorService actorService, IMapper mapper)
        {
            _actorService = actorService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _actorService.GetAllActors();
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actor = await _actorService.GetActorById(id);
            if (actor == null)
            {
                return NotFound($"Actor with ID {id} not found");
            }
            return Ok(actor);
        }
        [HttpGet("film/{filmId}")]
        public async Task<IActionResult> GetActorsByFilmId(int filmId)
        {
            var actors = await _actorService.GetActorsByFilmId(filmId);
            return Ok(actors);
        }
        [HttpPost]
        public async Task<IActionResult> AddActor([FromBody] CreateActorDto actorDto)
        {
            if (actorDto == null)
            {
                return BadRequest("Actor cannot be null");
            }
            await _actorService.AddActor(actorDto);
            var actor = _mapper.Map<Actor>(actorDto);

            return CreatedAtAction(nameof(GetActorById), new { id = actor.Id }, actorDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActor(int id, [FromBody] UpdateActorDto actorDto)
        {
            
            await _actorService.UpdateActor(id, actorDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {
            try
            {
                await _actorService.DeleteActor(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Actor with ID {id} not found");
            }
        }
    }
}
