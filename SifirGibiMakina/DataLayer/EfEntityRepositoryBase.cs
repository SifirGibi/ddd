using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;


namespace SifirGibiMakina.DataLayer
{
    public class EfEntityRepositoryBase<T, TContext>
      : IEntityRepository<T>
        where T : class,new()
        where TContext : DbContext
    {
        public EfEntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public T Add(T entity)
        {
            return Context.Set<T>().Add(entity);
        }

        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().FirstOrDefault(expression);
        }
        public bool GetAny(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Any(expression);
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AsQueryable().FirstOrDefaultAsync(expression);
        }

        public IEnumerable<T> GetList(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? Context.Set<T>().AsNoTracking()
                : Context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? await Context.Set<T>().ToListAsync()
                : await Context.Set<T>().Where(expression).ToListAsync();
        }

  


       
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            return Context.Set<T>();
        }

      

    

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await Context.Set<T>().CountAsync();
            }
            else
            {
                return await Context.Set<T>().CountAsync(expression);
            }
        }

        public int GetCount(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? Context.Set<T>().Count() : Context.Set<T>().Count(expression);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return Context.Set<T>().Where(where);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Context.Set<T>().OrderByDescending(orderBy);
            return Context.Set<T>().OrderBy(orderBy);
        }

        public T Find(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public T InTransaction<T>(Func<T> action, Action successAction = null, Action<Exception> exceptionAction = null)
        {
            var result = default(T);
            try
            {
                using (var tx = Context.Database.BeginTransaction())
                {
                    result = action();
                    SaveChanges();
                    tx.Commit();
                }

                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                if (exceptionAction != null)
                {
                    exceptionAction(ex);
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

    }
}