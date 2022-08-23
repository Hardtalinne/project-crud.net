using Microsoft.AspNetCore.Mvc;
using ProjectCrud.Application.Services;
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _productService.FindAllAsync();
            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet, Route("{productId}")]
        public async Task<IActionResult> GetAsync(Guid productId)
        {
            var result = await _productService.FindByIdAsync(productId);
            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProductDto productDto)
        {
            var result = await _productService.CreateAsync(productDto);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut, Route("{productId}")]
        public async Task<IActionResult> PutAsync(Guid productId, [FromBody] ProductDto productDto)
        {
            productDto.Id = productId;
            var result = await _productService.UpdateAsync(productDto);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{productId}")]
        public async Task<IActionResult> DeleteAsync(Guid productId)
        {
            var result = await _productService.DeleteAsync(productId);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
