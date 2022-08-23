using Microsoft.AspNetCore.Mvc;
using ProjectCrud.Application.Services;
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await _categoryService.FindAllAsync();
            if (result.Sucess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet, Route("{categoryId}")]
        public async Task<IActionResult> GetAsync(Guid categoryId)
        {
            var result = await _categoryService.FindByIdAsync(categoryId);
            if (result.Sucess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryDto categoryDto)
        {
            var result = await _categoryService.CreateAsync(categoryDto);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete, Route("{categoryId}")]
        public async Task<IActionResult> DeleteAsync(Guid categoryId)
        {
            var result = await _categoryService.DeleteAsync(categoryId);

            if (result.Sucess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
