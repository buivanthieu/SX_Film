using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Models;
using WebBackend.Services.Generic;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IGenericService<Tag> _tagService;
        public TagsController(IGenericService<Tag> tagService)
        {
            _tagService = tagService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetAll();
            return Ok(tags);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tag = await _tagService.GetById(id);
            return Ok(tag);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Find([FromQuery] string name)
        {
            var tags = await _tagService.Find(t => t.Name.Contains(name));
            return Ok(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Tag tag)
        {
            if (tag == null)
            {
                return BadRequest("Tag cannot be null");
            }
            await _tagService.Add(tag);
            return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tag tag)
        {
            if (tag == null || tag.Id != id)
            {
                return BadRequest("Tag is null or ID mismatch");
            }
            var existingTag = await _tagService.GetById(id);
            if (existingTag == null)
            {
                return NotFound($"Tag with ID {id} not found");
            }
            await _tagService.Update(tag);
            return Ok(tag);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingTag = await _tagService.GetById(id);
            if (existingTag == null)
            {
                return NotFound($"Tag with ID {id} not found");
            }
            await _tagService.Delete(id);
            return Ok();
        }
    }
}
