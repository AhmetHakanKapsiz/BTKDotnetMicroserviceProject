using AutoMapper;
using BtkAkademi.Service.ProductAPI.Models;
using BtkAkademi.Service.ProductAPI.Models.Dto;

namespace BtkAkademi.Service.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
