using AutoMapper;
using Basket.Application.Responses;
using Basket.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Basket.Application.Mappers
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponse>().ReverseMap();
        }
    }
}