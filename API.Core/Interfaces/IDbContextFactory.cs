using API.Core.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Interfaces
{
    public interface IDbContextFactory
    {
        PlanetsDatabaseContext CreateDbContext();
    }
}
