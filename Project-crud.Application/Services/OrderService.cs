using AutoMapper;
using ProjectCrud.Domain.DTOs;
using ProjectCrud.Domain.Entity;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Domain.Validations;

namespace ProjectCrud.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IMapper mapper,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<ResultService<OrderResponseDto>> CreateAsync(OrderDto orderDto)
        {
            if (orderDto == null)
                return ResultService.Fail<OrderResponseDto>("Pedido deve ser informado");

            var validationResult = await new OrderDtoValidator().ValidateAsync(orderDto);
            if (!validationResult.IsValid)
                return ResultService.RequestError<OrderResponseDto>("Um ou mais erros foram encontrados", validationResult);

            List<Guid> productsIds = new List<Guid>();
            foreach (int product in orderDto.CodeProducts)
            {
                var prod = await _productRepository.FindByCodeAsync(product);
                if (prod == null)
                {
                    return ResultService.Fail<OrderResponseDto>("Produto nao encontrado");
                }
                productsIds.Add(prod.Id);
            }

            var order = new Order();
            var orderPersist = await _orderRepository.CreateAsync(order);
            var orderMapped = _mapper.Map<OrderResponseDto>(orderPersist);

            foreach (Guid productId in productsIds)
            {
                var orderProduct = new OrderProduct(orderMapped.Id, productId);
                await _orderRepository.CreateOrderProductAsync(orderProduct);
            }
            return ResultService.Ok(orderMapped);
        }

        public async Task<ResultService> DeleteAsync(Guid orderId)
        {
            if (orderId == Guid.Empty)
                return ResultService.Fail<OrderResponseDto>("Id deve ser informado");

            var order = await _orderRepository.FindByIdAsync(orderId);
            if (order == null)
                return ResultService.Fail<OrderResponseDto>("Pedido não encontrado");

            if (await _orderRepository.DeleteAsync(order))
                return ResultService.Ok("Pedido removido com sucesso");

            return ResultService.Fail<OrderResponseDto>("Ocorreu um erro ao remover pedido");
        }

        public async Task<ResultService<OrderResponseDto>> FindByIdAsync(Guid orderId)
        {
            if (orderId == Guid.Empty)
                return ResultService.Fail<OrderResponseDto>("Id deve ser informado");

            var order = await _orderRepository.FindByIdAsync(orderId);
            if (order == null)
                return ResultService.Fail<OrderResponseDto>("Pedido não encontrado");

            var orderMapped = _mapper.Map<OrderResponseDto>(order);
            return ResultService.Ok(orderMapped);
        }

        public async Task<ResultService<ICollection<OrderResponseDto>>> FindAllAsync()
        {
            var orders = await _orderRepository.FindAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<OrderResponseDto>>(orders));
        }
    }
}
