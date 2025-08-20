using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebBackend.Services.Films;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _filmService;
        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFilms()
        {
            var films = await _filmService.GetAllFilms();
            return Ok(films);
        }

        [HttpGet("genreId")]
        public async Task<IActionResult> GetFilmsByGenreId(int genreId)
        {
            var films = await _filmService.GetFilmsByGenreId(genreId);
            return Ok(films);
        }
        [HttpGet("tagId")]
        public async Task<IActionResult> GetFilmsByTagId(int tagId)
        {
            var films = await _filmService.GetFilmsByTagId(tagId);
            return Ok(films);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmById(int id)
        {
            var film = await _filmService.GetFilmById(id);
            if (film == null)
            {
                return NotFound();
            }
            return Ok(film);
        }
    }
}
