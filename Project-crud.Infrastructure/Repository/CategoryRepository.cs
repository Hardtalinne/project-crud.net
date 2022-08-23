using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectCrud.Domain.Entity;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Infrastructure.Context;

namespace ProjectCrud.Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProjectCrudDbContext _dbContext;
        private readonly ILogger<CategoryRepository> _logger;

        public CategoryRepository(ProjectCrudDbContext dbContext, ILogger<CategoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                _dbContext.Add(category);
                await _dbContext.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return category;
            }
        }

        public async Task<bool> DeleteAsync(Category category)
        {
            try
            {
                _dbContext.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Category?> FindByIdAsync(Guid categoryId)
        {
            return await _dbContext.Categories
                .FirstOrDefaultAsync(x => x.Id == categoryId);
        }

        public async Task<ICollection<Category>> FindAllAsync()
        {
            return await _dbContext.Categories
                .ToListAsync();
        }
    }
}
