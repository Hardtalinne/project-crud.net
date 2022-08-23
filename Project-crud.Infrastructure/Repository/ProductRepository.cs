using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectCrud.Domain.Entity;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Infrastructure.Context;

namespace ProjectCrud.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectCrudDbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ProjectCrudDbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            try
            {
                _dbContext.Add(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return product;
            }
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            try
            {
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                _dbContext.Update(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Product?> FindByCodeAsync(int code)
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Product?> FindByIdAsync(Guid id)
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Product>> FindAllAsync()
        {
            return await _dbContext.Products
                .Include(x => x.Category)
                .ToListAsync();
        }
    }
}
