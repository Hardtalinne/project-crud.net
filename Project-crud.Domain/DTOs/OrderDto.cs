namespace ProjectCrud.Domain.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public List<int> CodeProducts { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
