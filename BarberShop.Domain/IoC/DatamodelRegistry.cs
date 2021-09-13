using Microsoft.Extensions.DependencyInjection;
using BarberShop.Domain.Contexts;
using BarberShop.Domain.Repositories;
using BarberShop.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberShop.Domain.IoC
{
    public static class DatamodelRegistry
    {
        public static void AddDatamodelRegistry(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork<BaseDBContext>, ContextUnitOfWork>();
            
            //services.AddScoped<IUnitOfWork<BaseDBContext>, ContextUnitOfWork>();
            // IUnitOfWorkS


        }
    }
}
