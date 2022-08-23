using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Infrastructure.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(c => c.Description)
                .HasColumnName("Description")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Code)
                .HasColumnName("Code")
                .IsRequired();

            builder.Property(c => c.Value)
                .HasColumnName("Price")
                .HasPrecision(10, 2)
                .IsRequired();

            builder.Property(c => c.QuantityStock)
                .HasColumnName("Stock")
                .IsRequired();

            builder.Property(c => c.CategoryId)
                .HasColumnName("CategoryId")
                .IsRequired();
        }
    }
}
