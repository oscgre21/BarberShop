using Microsoft.Extensions.DependencyInjection;  
using BarberShop.Services.JWTFactory; 
using System;
using System.Collections.Generic;
using System.Text;
using BarberShop.Services.Global;
using BarberShop.Services.Base;
using BarberShop.Services.Logging;
using BarberShop.Services.Demo;

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
     
             

            services.AddScoped(typeof(IBaseEntityService<,>) , typeof(BaseEntityService<,>));
            
            services.AddScoped<IDemoServices, DemoServices>();

            services.AddScoped<ITestDemoServices, TestDemoServices>();

            // services.AddScoped<ILoggingService, SentryLogger>(); 
        }
    }
}
