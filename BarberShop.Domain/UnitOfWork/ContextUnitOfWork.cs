using BarberShop.Core.Basemodel.BaseEntity;
using BarberShop.Domain.Contexts;
using BarberShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.UnitOfWork
{
    public class ContextUnitOfWork : IUnitOfWork<BaseContext>
    {
        public BaseContext Context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public ContextUnitOfWork(IServiceProvider serviceProvider, BaseContext context)
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

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity, BaseDBContext>(this)) as IRepository<TEntity>;
        }
    }

    public class AuthUnitOfWork : IUnitOfWork<BaseDBContext>
    {
        public BaseDBContext Context { get; set; }
        public readonly IServiceProvider _serviceProvider;

        public AuthUnitOfWork(IServiceProvider serviceProvider, BaseDBContext context)
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

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
        {
            return (_serviceProvider.GetService(typeof(TEntity)) ?? new BaseRepository<TEntity,BaseDBContext>(this)) as IRepository<TEntity>;
        }
    }
}
