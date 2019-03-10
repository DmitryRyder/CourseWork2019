using Microsoft.EntityFrameworkCore;

namespace API.Core.Interfaces
{
    public interface IDbContextFactory
    {
        DbContext CreateDbContext(ContextType type, string path);
    }
}
