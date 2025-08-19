using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.SearchLogs;
using WebBackend.Models;
using WebBackend.Services.Generic;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchLogsController : ControllerBase
    {
        private readonly IGenericService<SearchLog> _searchLogService;
        public SearchLogsController(IGenericService<SearchLog> searchLogService)
        {
            _searchLogService = searchLogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var searchLogs = await _searchLogService.GetAll();
            return Ok(searchLogs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var searchLog = await _searchLogService.GetById(id);
            if (searchLog == null)
            {
                return NotFound($"SearchLog with ID {id} not found");
            }
            return Ok(searchLog);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSearchLogDto searchLogDto)
        {
            var searchLog = new SearchLog
            {
                UserId = searchLogDto.UserId,
                Keyword = searchLogDto.Keyword,
                SearchedAt = searchLogDto.SearchedAt

            };

            if (searchLog == null)
            {
                return BadRequest("SearchLog cannot be null");
            }
            await _searchLogService.Add(searchLog);
            return CreatedAtAction(nameof(GetById), new { id = searchLog.Id }, searchLog);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSearchLogDto searchLogDto)
        {
            var existingSearchLog = await _searchLogService.GetById(id);
            if (existingSearchLog == null)
            {
                return NotFound($"SearchLog with ID {id} not found");
            }

            existingSearchLog.UserId = searchLogDto.UserId;
            existingSearchLog.Keyword = searchLogDto.Keyword;
            existingSearchLog.SearchedAt = searchLogDto.SearchedAt;


            await _searchLogService.Update(existingSearchLog);
            return Ok(existingSearchLog);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSearchLog = await _searchLogService.GetById(id);
            if (existingSearchLog == null)
            {
                return NotFound($"SearchLog with ID {id} not found");
            }
            await _searchLogService.Delete(id);
            return Ok();
        }
    }
}
