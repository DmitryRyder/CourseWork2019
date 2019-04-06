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
                    case ContextType.PowerConsumptionContext:
                        {
                            var optionsBuilder = new DbContextOptionsBuilder<AccountingForEnergyContext>();
                            optionsBuilder = optionsBuilder.UseSqlServer(path);
                            context = new AccountingForEnergyContext(optionsBuilder.Options);
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
