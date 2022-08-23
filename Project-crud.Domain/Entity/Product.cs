namespace ProjectCrud.Domain.Entity
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public int Code { get; set; }
        public decimal Value { get; set; }
        public int QuantityStock { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Product(Guid id, string description, int code, decimal value, int quantityStock, Guid categoryId)
        {
            Id = id;
            Description = description;
            Code = code;
            Value = value;
            QuantityStock = quantityStock;
            CategoryId = categoryId;
        }

        public Product(string description, int code, decimal value, int quantityStock, Guid categoryId)
        {
            Description = description;
            Code = code;
            Value = value;
            QuantityStock = quantityStock;
            CategoryId = categoryId;
        }
    }
}
