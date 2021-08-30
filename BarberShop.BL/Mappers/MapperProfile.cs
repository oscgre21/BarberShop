using AutoMapper;
using BarberShop.BL.DTOs;
using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Domain.Entities.Global;
using BarberShop.BL.DTOs.Global; 

namespace BarberShop.BL.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Globales
            CreateMap<Demo, DemoDto>()
                .ReverseMap();
    

            #endregion
                         

        }
    }
}
