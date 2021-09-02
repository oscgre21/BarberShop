using BarberShop.Core.Basemodel.BaseEntity;
using BarberShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;
        Task<int> Commit();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork
    {
        TContext Context { get; }
    }
    public interface IUnitOfWorkS<TContext> : IUnitOfWork
    {
        TContext Context { get; }
    }
}
