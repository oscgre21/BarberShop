using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BarberShop.BL.DTOs.Base;
using BarberShop.Core.Basemodel.BaseEntity;
using BarberShop.Domain.Contexts;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.UnitOfWork;
using BarberShop.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentValidation.Results;
using BarberShop.API.Extensions;
namespace BarberShop.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiFactoryController
    {
        public BaseApiFactoryController()
        {
        }
    }
}
