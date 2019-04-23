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
                    case ContextType.RentalRoomsContext:
                        {
                            var optionsBuilder = new DbContextOptionsBuilder<RentalRoomsContext>();
                            optionsBuilder = optionsBuilder.UseSqlServer(path);
                            context = new RentalRoomsContext(optionsBuilder.Options);
                        }
                        break;
                    default: break;
                }
            }
            catch (NullReferenceException) { Console.WriteLine("Exception is here"); }

            return context;
        }
    }
}
