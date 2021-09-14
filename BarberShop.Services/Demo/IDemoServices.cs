using System;
using BarberShop.BL.DTOs.Global;
using BarberShop.Services.Base;
using BarberShop.Domain.Entities.Global;
using BarberShop.Domain.UnitOfWork;
using BarberShop.Domain.Contexts;
using AutoMapper;

namespace BarberShop.Services.Demo
{

    public interface IDemoServices : IBaseEntityService<BarberShop.Domain.Entities.Global.Demo, DemoDto>
    {

    }
    public class DemoServices : BaseEntityService<BarberShop.Domain.Entities.Global.Demo, DemoDto, IUnitOfWork<BaseDBContext>>, IDemoServices
    {
        public DemoServices(IUnitOfWork<BaseDBContext> uow, IMapper mapper)
           : base(uow, mapper)
        {

        }
    }
}
