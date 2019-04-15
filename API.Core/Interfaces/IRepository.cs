using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Models;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> Query(Guid id);
        void Save();
        void SaveAsync();
        void Insert(T model);
        void InsertAsync(T model);
        void Update(T model);
        void DeleteByIdAsync(Guid id);
        void DeleteById(Guid id);
        void AddRange(IList<T> models);
        void UpdateRange(IList<T> models);
        //IQueryable<T> Include(Expression<Func<T, object>> criteria);
        //IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        Task<List<T>> IncludeAsync(params Expression<Func<T, object>>[] includes);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
