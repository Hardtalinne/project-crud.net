
using ProjectCrud.Domain.DTOs;

namespace ProjectCrud.Application.Services
{
    public interface IOrderService
    {
        Task<ResultService<OrderResponseDto>> CreateAsync(OrderDto orderDto);
        Task<ResultService<ICollection<OrderResponseDto>>> FindAllAsync();
        Task<ResultService<OrderResponseDto>> FindByIdAsync(Guid orderId);
        Task<ResultService> DeleteAsync(Guid orderId);
    }
}
