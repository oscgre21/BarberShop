using Microsoft.Extensions.DependencyInjection;  
using BarberShop.Services.JWTFactory; 
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Services.Global;
using BarberShop.Services.Base;
using BarberShop.Services.Logging;
using BarberShop.Services.Demo;
using BarberShop.Services.Auth;
using AutoMapper;
using BarberShop.Domain.UnitOfWork;
using BarberShop.Domain.Contexts;

namespace BarberShop.Services.IoC
{
    public static class ServicesRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddOnlyEntityServicesRegistry();
            services.AddScoped<IJwtFactory, JwtFactory>();  
    
        }

        public static void AddOnlyEntityServicesRegistry(this IServiceCollection services)
        { 
      
            services.AddScoped(typeof(IBaseEntityService<,>) , typeof(BaseEntityService<,,>));

            /*
            var sp = services.BuildServiceProvider();
            var _mapper = sp.GetRequiredService<IMapper>();
            var db = sp.GetRequiredService<IUnitOfWork<BaseDBContext>>();// as IUnitOfWork<BaseContext>;
            */
            services.AddScoped<IDemoServices, DemoServices>();

            services.AddScoped<IProductServices, ProductServices>();


            // services.AddScoped<ILoggingService, SentryLogger>(); 
        }
    }
}
