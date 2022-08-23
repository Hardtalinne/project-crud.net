using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCrud.Application.Services;
using ProjectCrud.Domain.Mappings;
using ProjectCrud.Domain.Repository;
using ProjectCrud.Infra.Repository;
using ProjectCrud.Infrastructure.Context;

namespace ProjectCrud.Infrastructure.Dependecies
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqliteConnectionString");
            services.AddSqlite<ProjectCrudDbContext>(connectionString);

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoForEntityMapping));
            services.AddAutoMapper(typeof(EntityForDtoMapping));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
