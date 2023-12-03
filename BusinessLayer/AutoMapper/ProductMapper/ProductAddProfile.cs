using AutoMapper;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AutoMapper.ProductMapper
{
    public class ProductAddProfile : Profile
    {
        public ProductAddProfile()
        {
            CreateMap<Product, HamburgerAddDTO>().ReverseMap();
            CreateMap<Product, BeverageAddDTO>().ReverseMap();
            CreateMap<Product, MenuAddDTO>().ReverseMap();
            CreateMap<Product, AdditionalAddDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
        }
    }
}

