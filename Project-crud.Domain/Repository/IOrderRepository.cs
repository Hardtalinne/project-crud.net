using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<OrderProduct> CreateOrderProductAsync(OrderProduct orderProduct);
        Task<bool> DeleteAsync(Order order);
        Task<ICollection<Order>> FindAllAsync();
        Task<Order?> FindByIdAsync(Guid orderId);
    }
}
