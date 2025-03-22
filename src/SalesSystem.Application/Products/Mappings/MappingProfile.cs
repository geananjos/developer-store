using AutoMapper;
using SalesSystem.Application.Products.Commands.CreateProduct;
using SalesSystem.Application.Products.DTOs;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Application.Products.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.Rating, opt =>
                    opt.MapFrom(src => new Rating(src.RatingRate, src.RatingCount)));

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.RatingRate, opt => opt.MapFrom(src => src.Rating.Rate))
                .ForMember(dest => dest.RatingCount, opt => opt.MapFrom(src => src.Rating.Count));
        }
    }
}
