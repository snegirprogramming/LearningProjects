using Microsoft.EntityFrameworkCore;

namespace Gatherly.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
}
