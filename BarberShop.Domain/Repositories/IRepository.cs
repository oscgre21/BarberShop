using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Repositories
{
    public interface IRepository<DB> : IDisposable //where T : class
        where DB : DbContext
    {
        Task<IEnumerable<T>> Get<T>(Expression<Func<T, bool>> predicate = null, 
                int? page = null,
                int? pageSize = null,
                SortExpression<T> sortExpressions = null,
                bool trackEntities = true,
                params Expression<Func<T, object>>[] includeProperties)  where T : class;

        Task<T> First<T>(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById<T>(Guid id, params Expression<Func<T, object>>[] includeProperties);

        void Add<T>(T entity);
        void Add<T>(params T[] entities);
        void Add<T>(IEnumerable<T> entities);

        void Delete<T>(T entity);
        Task Delete<T>(Guid id);
        void Delete<T>(params T[] entities);
        void Delete<T>(IEnumerable<T> entities); 
        void Update<T>(T entity);
        void Update<T>(params T[] entities);
        void Update<T>(IEnumerable<T> entities);
        void Detached<T>(T entity);
    }
    
}
