using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCrud.Domain.Entity
{
    public class Order
    {
        public Guid Id { get; private set; }
        public DateTime DateOrder { get; set; }
        public ICollection<OrderProduct> OrderProduct { get; set; }

        [NotMapped]
        public List<Guid>? ProductId { get; set; }

        public Order(Guid id, List<Guid> productId)
        {
            Id = id;
            ProductId = productId;
            DateOrder = DateTime.UtcNow;
        }

        public Order()
        {
            DateOrder = DateTime.UtcNow;
        }

    }
}
