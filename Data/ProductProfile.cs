using SideHustleShop.DTOs;
using SideHustleShop.Models;
using AutoMapper;

namespace SideHustleShop.Data
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
