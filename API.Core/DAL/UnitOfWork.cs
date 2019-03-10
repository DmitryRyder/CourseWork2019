using API.Core.Interfaces;
using API.Core.Repositories;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Core.DAL
{
    public class UnitOfWork
    {
        private readonly DbContext context;
        private IRepository<Planet> planetRepository;
        private IRepository<Sattelite> satteliteReposiroty;
        public UnitOfWork(IDbContextFactory contextFactory)
        {
            context = contextFactory.CreateDbContext();
            planetRepository = new Repository<Planet>(context);
            satteliteReposiroty = new Repository<Sattelite>(context);
        }

        public IRepository<Planet> PlanetRepository
        {
            get
            {
                if (planetRepository == null)
                    planetRepository = new Repository<Planet>(context); ;
                return planetRepository;
            }
        }

        public IRepository<Sattelite> SatteliteReposiroty
        {
            get
            {
                if (satteliteReposiroty == null)
                    satteliteReposiroty = new Repository<Sattelite>(context);
                return satteliteReposiroty;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
