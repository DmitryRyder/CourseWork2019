using API.Core.Interfaces;
using API.Core.Repositories;
using Common;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Core.DAL
{
    public class UnitOfWork
    {
        private Dictionary<Type, object> repositories;
        private readonly DbContext context;
        private readonly object _lock = new object();
        private bool updated = false;
        public UnitOfWork(IDbContextFactory contextFactory)
        {
            repositories = new Dictionary<Type, object>();
            context = contextFactory.CreateDbContext(ContextType.PowerConsumptionContext, Constants.PowerConsumptionDatabase);
        }

        public IRepository<T> GetRepository<T>() where T : BaseModel
        {
            //lock (_lock)
            //{
                if (repositories.Keys.Contains(typeof(T)))
                {
                    return repositories[typeof(T)] as IRepository<T>;
                }

                var rep = new Repository<T>(context);
                repositories.Add(typeof(T), rep);

            return rep;
            //}
        }

        public void Save()
        {
            var currentContext = context;


            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
