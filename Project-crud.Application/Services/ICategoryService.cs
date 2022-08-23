
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.Application.Services
{
    public interface ICategoryService
    {
        Task<ResultService<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<ResultService<ICollection<CategoryDto>>> FindAllAsync();
        Task<ResultService<CategoryDto>> FindByIdAsync(Guid categoryId);
        Task<ResultService> DeleteAsync(Guid categoryId);
    }
}
