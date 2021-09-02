using AutoMapper;
using BarberShop.BL.DTOs;
using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Domain.Entities.Global;
using BarberShop.BL.DTOs.Global;
using BarberShop.Domain.Entities.DataPerson;
using BarberShop.Domain.Entities.Users;

namespace BarberShop.BL.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Globales
            CreateMap<PersonData, PersonDTO>()
                .ReverseMap();
            CreateMap<UserIdentity, UserCredentialsDto>()
             .ReverseMap();

            #endregion


        }
    }
}
