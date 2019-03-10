using API.Core.Contexts;
using API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Core.DAL
{
    public class DbContextFactory : IDbContextFactory
    {
        DbContext context;
        public DbContext CreateDbContext(ContextType type, string path)
        {
            try
            {
                switch (type)
                {
                    case ContextType.PlanetDatabaseContext:
                        {
                            var optionsBuilder = new DbContextOptionsBuilder<PlanetsDatabaseContext>();
                            optionsBuilder = optionsBuilder.UseSqlServer(path);
                            context = new PlanetsDatabaseContext(optionsBuilder.Options);
                        }
                        break;
                    default: break;
                }
            }
            catch (NullReferenceException) { Console.WriteLine("Exception is here"); }

            return context;
        }

        //public DbContext CreateDbContext(Type tp, string path)
        //{
        //    //IConfigurationRoot configuration = new ConfigurationBuilder()
        //    //.SetBasePath(Directory.GetCurrentDirectory())
        //    //.AddJsonFile("appsettings.json")
        //    //.Build();

        //    var optionsBuilder = new DbContextOptionsBuilder<PlanetsDatabaseContext>();
        //    optionsBuilder.UseSqlServer(path/*, b => b.MigrationsAssembly("EfDesignDemo.EF.Design")*/);
        //    return new PlanetsDatabaseContext(optionsBuilder.Options); 
        //}
    }
}
