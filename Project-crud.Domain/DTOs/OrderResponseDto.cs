namespace ProjectCrud.Domain.DTOs
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public OrderProductDto? OrderProduct { get; set; }
    }
}
