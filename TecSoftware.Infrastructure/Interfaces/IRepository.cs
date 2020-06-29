using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TecSoftware.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(List<Expression<Func<T, object>>> includes);

        Task<T> Single(Expression<Func<T, bool>> predicate);
        Task<T> Single(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes);

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate,
            List<Expression<Func<T, object>>> includes);

        bool Exist(T entity);
        Task<bool> Exist(Expression<Func<T, bool>> predicate);

        Task Create(T entity);
        Task Update(T entity);

        void Delete(T entity);
        Task Delete(Expression<Func<T, bool>> predicate);
    }
}
