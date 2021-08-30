using System;
using BarberShop.BL.DTOs.Global;
using BarberShop.Services.Base;
using BarberShop.Domain.Entities.Global;
using BarberShop.Domain.UnitOfWork;
using BarberShop.Domain.Contexts;
using AutoMapper;
using BarberShop.BL.DTOs.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberShop.Services.Demo
{ 
    public interface ITestDemoServicesGlobal<TEntityDto>
        where TEntityDto : class, IBaseEntityDto
    {
        Task<IEnumerable<TEntityDto>> GetListOfN();

    }
    public abstract class AServicesGlobal<TEntityDto>
     where TEntityDto : class, IBaseEntityDto
    {
        protected abstract Task<IEnumerable<TEntityDto>> GetListOfN();
    }

    public interface ITestDemoServices : IBaseEntityServicesTest<BarberShop.Domain.Entities.Global.Demo>
    {

    }
    public class TestDemoServices : BaseEntityServicesTestImpl<BarberShop.Domain.Entities.Global.Demo>, ITestDemoServices, ITestDemoServicesGlobal<DemoDto>
    {
        public TestDemoServices(IUnitOfWork<BaseDBContext> uow, IMapper mapper)
           : base(uow, mapper)
        {

        }
        public Task<IEnumerable<DemoDto>> GetListOfN()
        {
            return GetWithMap<DemoDto>();
        }
    } 
}
