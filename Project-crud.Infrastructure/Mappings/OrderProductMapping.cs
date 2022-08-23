using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Infra.Mapeamentos
{
    public class OrderProductMapping : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProduct");

            builder.HasKey(x => new { x.ProductId, x.OrderId });

            builder.Property(x => x.ProductId)
                .HasColumnName("ProductId")
                .IsRequired();

            builder.Property(x => x.OrderId)
                .HasColumnName("OrderId")
                .IsRequired();

            builder.HasOne(x => x.Order)
                .WithMany(y => y.OrderProduct)
                .HasForeignKey(xy => xy.OrderId);


            builder.HasOne(x => x.Product)
                .WithMany(y => y.OrderProduct)
                .HasForeignKey(xy => xy.ProductId);
        }
    }
}
