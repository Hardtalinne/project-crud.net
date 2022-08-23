namespace ProjectCrud.Domain.DTOs
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public ICollection<OrderProductDto> OrderProduct { get; set; }
    }
}
