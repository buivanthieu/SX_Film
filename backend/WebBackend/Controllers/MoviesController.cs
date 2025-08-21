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
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] CreateMovieDto movieDto)
        {
            if (movieDto == null)
                return BadRequest("Movie cannot be null");

            await _movieService.AddMovie(movieDto);
            return Ok(movieDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            
            await _movieService.UpdateMovie(id, movieDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            
            await _movieService.DeleteMovie(id);
            return Ok();
        }

    }
}
