using AutoMapper;
using ProjectCrud.Domain.DTOs;
using ProjectCrud.Domain.Entity;

namespace ProjectCrud.Domain.Mappings
{
    public class DtoForEntityMapping : Profile
    {
        public DtoForEntityMapping()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<OrderResponseDto, Order>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
