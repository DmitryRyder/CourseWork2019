using API.Core.Interfaces;
using API.Core.Repositories;
using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        private IRepository<TestData> repository;

        public UnitOfWork(IDbContextFactory contextFactory)
        {
            context = contextFactory.CreateDbContext();
            repository = new GenericRepository<TestData>(context);
        }

        public void Dispose()
        {
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IRepository<TestData> GetRepository()
        {
            return repository;
        }
    }
}
