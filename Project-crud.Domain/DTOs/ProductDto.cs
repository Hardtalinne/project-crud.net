namespace ProjectCrud.Domain.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string? Description { get; set; }
        public int QuantityStock { get; set; }
        public decimal Value { get; set; }
        public CategoryDto Category { get; set; }
    }
}
