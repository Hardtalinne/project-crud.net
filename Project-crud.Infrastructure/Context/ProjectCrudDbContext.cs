using Microsoft.EntityFrameworkCore;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Infrastructure.Context
{
    public class ProjectCrudDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        public ProjectCrudDbContext(DbContextOptions<ProjectCrudDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectCrudDbContext).Assembly);
        }
    }
}
