using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectCrud.Domain.Entity;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Infrastructure.Context;

namespace ProjectCrud.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProjectCrudDbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(ProjectCrudDbContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            try
            {
                _dbContext.Add(order);
                await _dbContext.SaveChangesAsync();

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return order;
            }
        }

        public async Task<OrderProduct> CreateOrderProductAsync(OrderProduct orderProduct)
        {
            try
            {
                _dbContext.Add(orderProduct);
                await _dbContext.SaveChangesAsync();
                return orderProduct;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return orderProduct;
            }
        }


        public async Task<bool> DeleteAsync(Order order)
        {
            try
            {
                _dbContext.Remove(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<Order?> FindByIdAsync(Guid orderId)
        {
            return await _dbContext.Orders
                 .FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<ICollection<Order>> FindAllAsync()
        {
            return await _dbContext.Orders
                .Include(x => x.OrderProduct)
                .ToListAsync();
        }
    }
}
