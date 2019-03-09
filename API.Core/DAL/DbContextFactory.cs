using API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace API.Core.DAL
{
    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        private DbContext context;

        public DbContext CreateDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

            //ToDo need the test for this connectionString
            optionsBuilder.UseSqlServer("DefaultConnection"/*, b => b.MigrationsAssembly("EfDesignDemo.EF.Design")*/);
            context = new DbContext(optionsBuilder.Options);
            return context;
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
