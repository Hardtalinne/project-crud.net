using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Infra.Mapeamentos
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey("Id");

            builder.Property(x => x.DateOrder)
                .HasColumnName("Date")
                .IsRequired();

        }
    }
}
