using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.Movies;
using WebBackend.Services.Movies;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] CreateMovieDto movieDto)
        {
            if (movieDto == null)
                return BadRequest("Movie cannot be null");

            await _movieService.AddMovie(movieDto);

            // Trả về 201 Created kèm location
            return Ok();
        }

    }
}
