using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Domain.Repository
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(Product product);
        Task<Product?> FindByIdAsync(Guid id);
        Task<Product?> FindByCodeAsync(int code);
        Task<ICollection<Product>> FindAllAsync();
    }
}
