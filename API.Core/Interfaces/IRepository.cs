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
        T GetById(int? id);
        Task<T> GetByIdAsync(int? id);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        IQueryable<T> Query(int id);
        void Save();
        void SaveAsync();
        void Insert(T model);
        void InsertAsync(T model);
        void Update(T model);
        void DeleteByIdAsync(int id);
        void DeleteById(int id);
        IQueryable<T> Include(Expression<Func<T, object>> criteria);
    }
}
