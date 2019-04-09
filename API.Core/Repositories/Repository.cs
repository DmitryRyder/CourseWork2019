using API.Core.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Core.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : BaseModel
    {
        private DbContext context;
        private DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public T GetById(int? id)
        {
            return id is null ? null : dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return id is null ? null : await dbSet.FindAsync(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public IQueryable<T> Query(int id)
        {
            return context.Query<T>().Where(i => i.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async void SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IIncludableQueryable<T, object> query = null;

            if (includes.Length > 0)
            {
                query = dbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? dbSet : (IQueryable<T>)query;
        }

        public void Insert(T model)
        {
            dbSet.Add(model);
        }

        public async void InsertAsync(T model)
        {
            await dbSet.AddAsync(model);
        }

        public async void AddRange(IList<T> models)
        {
            await dbSet.AddRangeAsync(models);
        }

        public void UpdateRange(IList<T> models)
        {
            dbSet.UpdateRange(models);
        }

        public void Update(T model)
        {
            dbSet.Attach(model);
            context.Entry(model).State = EntityState.Modified;
        }

        public async void DeleteByIdAsync(int id)
        {
            T entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            T entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
