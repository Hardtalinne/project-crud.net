using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.Application.Services
{
    public interface IProductService
    {
        Task<ResultService<ProductDto>> CreateAsync(ProductDto productDto);
        Task<ResultService> UpdateAsync(ProductDto productDto);
        Task<ResultService> DeleteAsync(Guid productId);
        Task<ResultService> FindByIdAsync(Guid productId);
        Task<ResultService<ICollection<ProductDto>>> FindAllAsync();
    }
}
