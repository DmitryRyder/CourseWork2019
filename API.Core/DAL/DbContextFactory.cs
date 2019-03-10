using API.Core.Contexts;
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
        private PlanetsDatabaseContext context;

        public PlanetsDatabaseContext CreateDbContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PlanetsDatabaseContext>();

            //ToDo need the test for this connectionString
            optionsBuilder.UseSqlServer("workstation id=PlanetsDatabaseContext.mssql.somee.com;packet size=4096;user id=Ryder_SQLLogin_1;pwd=tfah5u3xng;data source=PlanetsDatabaseContext.mssql.somee.com;persist security info=False;Initial Catalog=PlanetsDatabaseContext;"/*, b => b.MigrationsAssembly("EfDesignDemo.EF.Design")*/);
            context = new PlanetsDatabaseContext(optionsBuilder.Options);
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
