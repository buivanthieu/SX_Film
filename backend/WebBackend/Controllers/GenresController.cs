using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.Genres;
using WebBackend.Models;
using WebBackend.Services.Generic;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenericService<Genre> _genreService;
        public GenresController(IGenericService<Genre> genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.GetAll();
            return Ok(genres);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var genre = await _genreService.GetById(id);
            if (genre == null)
            {
                return NotFound($"Genre with ID {id} not found");
            }
            return Ok(genre);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Find([FromQuery] string name)
        {
            var genres = await _genreService.Find(t => t.Name.Contains(name));
            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGenreDto genreDto)
        {
            var genre = new Genre
            {
                Name = genreDto.Name,
                Description = genreDto.Description
            };

            if (genre == null)
            {
                return BadRequest("Genre cannot be null");
            }
            await _genreService.Add(genre);
            return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGenreDto genreDto)
        {
            var existingGenre = await _genreService.GetById(id);
            if (existingGenre == null)
            {
                return NotFound($"Genre with ID {id} not found");
            }
            existingGenre.Name = genreDto.Name;
            existingGenre.Description = genreDto.Description;

            await _genreService.Update(existingGenre);
            return Ok(existingGenre);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingGenre = await _genreService.GetById(id);
            if (existingGenre == null)
            {
                return NotFound($"Genre with ID {id} not found");
            }
            await _genreService.Delete(id);
            return Ok();
        }
    }
}
