using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Domain.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
        Task<ICollection<Category>> FindAllAsync();
        Task<Category?> FindByIdAsync(Guid categoryId);
    }
}
