using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackend.Dtos.ProductionCompanies;
using WebBackend.Models;
using WebBackend.Services.Generic;

namespace WebBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionCompaniesController : ControllerBase
    {
        private readonly IGenericService<ProductionCompany> _productionCompanyService;
        public ProductionCompaniesController(IGenericService<ProductionCompany> productionCompanyService)
        {
            _productionCompanyService = productionCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productionCompanies = await _productionCompanyService.GetAll();
            return Ok(productionCompanies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var productionCompany = await _productionCompanyService.GetById(id);
            if (productionCompany == null)
            {
                return NotFound($"ProductionCompany with ID {id} not found");
            }
            return Ok(productionCompany);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Find([FromQuery] string name)
        {
            var productionCompanies = await _productionCompanyService.Find(t => t.Name.Contains(name));
            return Ok(productionCompanies);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductionCompanyDto productionCompanyDto)
        {
            var productionCompany = new ProductionCompany
            {
                Name = productionCompanyDto.Name,
                Description = productionCompanyDto.Description,
                Country = productionCompanyDto.Country,
                LogoUrl = productionCompanyDto.LogoUrl
            };

            if (productionCompany == null)
            {
                return BadRequest("ProductionCompany cannot be null");
            }
            await _productionCompanyService.Add(productionCompany);
            return CreatedAtAction(nameof(GetById), new { id = productionCompany.Id }, productionCompany);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductionCompanyDto productionCompanyDto)
        {
            var existingProductionCompany = await _productionCompanyService.GetById(id);
            if (existingProductionCompany == null)
            {
                return NotFound($"ProductionCompany with ID {id} not found");
            }
            existingProductionCompany.Name = productionCompanyDto.Name;
            existingProductionCompany.Description = productionCompanyDto.Description;
            existingProductionCompany.Country = productionCompanyDto.Country;
            existingProductionCompany.LogoUrl = productionCompanyDto.LogoUrl;

            await _productionCompanyService.Update(existingProductionCompany);
            return Ok(existingProductionCompany);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProductionCompany = await _productionCompanyService.GetById(id);
            if (existingProductionCompany == null)
            {
                return NotFound($"ProductionCompany with ID {id} not found");
            }
            await _productionCompanyService.Delete(id);
            return Ok();
        }
    }
}
