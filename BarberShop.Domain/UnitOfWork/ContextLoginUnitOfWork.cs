using BarberShop.Core.Basemodel.BaseEntity;
using BarberShop.Domain.Contexts;
using BarberShop.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.UnitOfWork
{
    public class ContextLoginUnitOfWork : IUnitOfWork<LoginDBContext>
    {
        public LoginDBContext Context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public ContextLoginUnitOfWork(IServiceProvider serviceProvider, LoginDBContext context)
        {
            _serviceProvider = serviceProvider;
            this.Context = context;
        }

        public async Task<int> Commit()
        {
            var result = await Context.SaveChangesAsync();
            return result;
        }


        public void Dispose()
        {
            Context.Dispose();
        }

        public IRepository<DB,TEntity> GetRepository<DB,TEntity>() 
            where TEntity : class, IBaseEntity 
            where DB : class, DbContext
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<DB,TEntity>(this)) as IRepository<DB,TEntity>;
        }
    }
}
