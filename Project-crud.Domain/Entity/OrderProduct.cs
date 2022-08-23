namespace ProjectCrud.Domain.Entity
{
    public class OrderProduct
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        public OrderProduct(Guid orderId, Guid productId)
        {
            OrderId = orderId;
            ProductId = productId;
        }
    }
}
