using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using WebBackend.Dtos.Tags;
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
            if (tag == null)
            {
                return NotFound($"Tag with ID {id} not found");
            }
            return Ok(tag);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Find([FromQuery] string name)
        {
            var tags = await _tagService.Find(t => t.Name.Contains(name));
            return Ok(tags);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTagDto tagDto)
        {
            var tag = new Tag
            {
                Name = tagDto.Name,
                Description = tagDto.Description
            };

            if (tag == null)
            {
                return BadRequest("Tag cannot be null");
            }
            await _tagService.Add(tag);
            return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tag);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTagDto tagDto)
        { 
            var existingTag = await _tagService.GetById(id);
            if (existingTag == null)
            {
                return NotFound($"Tag with ID {id} not found");
            }
            existingTag.Name = tagDto.Name;
            existingTag.Description = tagDto.Description;

            await _tagService.Update(existingTag);
            return Ok(existingTag);
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
