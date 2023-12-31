﻿using AutoMapper;
using BtkAkademi.Service.CouponAPI.Models;
using BtkAkademi.Service.CouponAPI.Models.Dto;

namespace BtkAkademi.Service.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();

            });

            return mappingConfig;
        }
    }
}
