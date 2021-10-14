using AutoMapper;
using CartManagement.API.DTOs;
using CartManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();

            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();


        }
    }
}
