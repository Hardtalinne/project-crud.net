using AutoMapper;
using ProjectCrud.Domain.DTOs;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Domain.Mappings
{
    public class EntityForDtoMapping : Profile
    {
        public EntityForDtoMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
