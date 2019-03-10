using API.Core.DAL;
using API.Core.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
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

        public void Insert(T model)
        {
            dbSet.Add(model);
        }

        public async void InsertAsync(T model)
        {
            await dbSet.AddAsync(model);
        }

        public void Update(T model)
        {
            dbSet.Attach(model);
            context.Entry(model).State = EntityState.Modified;
        }

        public void Delete(T id)
        {
            T model = dbSet.Find(id);

            if (context.Entry(model).State == EntityState.Detached)
            {
                dbSet.Attach(model);
            }
            dbSet.Remove(model);
        }
    }
}
