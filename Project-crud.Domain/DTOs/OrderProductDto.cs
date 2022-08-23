namespace ProjectCrud.Domain.DTOs
{
    public class OrderProductDto
    {
        public Guid OrderId { get; set; }
        public OrderDto? Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto? Product { get; set; }
    }
}
