using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.Series;
using WebBackend.Services.Series;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriService _seriService;
        public SeriesController(ISeriService seriService)
        {
            _seriService = seriService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSeries()
        {
            var series = await _seriService.GetAllSeries();
            return Ok(series);
        }
        [HttpPost]
        public async Task<IActionResult> AddSeri([FromBody] CreateSeriDto seriDto)
        {
            if (seriDto == null)
                return BadRequest("Seri cannot be null");

            await _seriService.AddSeri(seriDto);
            return Ok(seriDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeri(int id, [FromBody] UpdateSeriDto seriDto)
        {

            await _seriService.UpdateSeri(seriDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeri(int id)
        {

            await _seriService.DeleteSeri(id);
            return NoContent();
        }
    }
}
