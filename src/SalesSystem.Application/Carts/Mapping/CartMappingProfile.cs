using AutoMapper;
using SalesSystem.Application.Carts.DTOs;
using SalesSystem.Domain.Carts;
using SalesSystem.Domain.Carts.ValueObjects;

namespace SalesSystem.Application.Carts.Mapping
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<Cart, CartDto>();
            CreateMap<CartProduct, CartProductDto>();
        }
    }
}
