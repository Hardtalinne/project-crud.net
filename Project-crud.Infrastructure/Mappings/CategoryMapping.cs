using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Infra.Mapeamentos
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");

            builder.HasKey("Id");

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .IsRequired();
        }
    }
}
