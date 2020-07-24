using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;
using TecSoftware.Infrastructure.Data.Catalogo;

namespace TecSoftware.Infrastructure
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll()
        {
            using (var context = new CatalogoInquilinoContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public IEnumerable<T> GetAll(List<Expression<Func<T, object>>> includes)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includes)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }

            using (var context = new CatalogoInquilinoContext())
            {
                IQueryable<T> query = context.Set<T>();
                includelist.ForEach(x => query = query.Include(x));
                return (IEnumerable<T>)query.ToList();
            }
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                return context.Set<T>().Where(predicate).ToList();
            }
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includes)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }

            using (var context = new CatalogoInquilinoContext())
            {
                IQueryable<T> query = context.Set<T>();

                includelist.ForEach(x => query = query.Include(x));

                return (IEnumerable<T>)query.Where(predicate).ToList();
            }
        }

        public async Task<T> Single(Expression<Func<T, bool>> predicate)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                return await context.Set<T>().FirstOrDefaultAsync(predicate);
            }
        }

        public async Task<T> Single(Expression<Func<T, bool>> predicate, List<Expression<Func<T, object>>> includes)
        {
            List<string> includelist = new List<string>();

            foreach (var item in includes)
            {
                MemberExpression body = item.Body as MemberExpression;
                if (body == null)
                    throw new ArgumentException("The body must be a member expression");

                includelist.Add(body.Member.Name);
            }

            using (var context = new CatalogoInquilinoContext())
            {
                IQueryable<T> query = context.Set<T>();
                includelist.ForEach(x => query = query.Include(x));
                return await query.FirstOrDefaultAsync(predicate);
            }
        }

        public bool Exist(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Exist(Expression<Func<T, bool>> predicate)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                return await context.Set<T>().AnyAsync(predicate);
            }
        }

        public async Task Create(T entity)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task Update(T entity)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public async Task Delete(Expression<Func<T, bool>> predicate)
        {
            using (var context = new CatalogoInquilinoContext())
            {
                var entities = context.Set<T>().Where(predicate).ToList();
                entities.ForEach(x => context.Entry(x).State = EntityState.Deleted);
                await context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<T, UniversalExtend>> source)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UniversalExtend>> SelectList(Expression<Func<T, bool>> predicate,
            Expression<Func<T, UniversalExtend>> source)
        {
            throw new NotImplementedException();
        }
    }
}
