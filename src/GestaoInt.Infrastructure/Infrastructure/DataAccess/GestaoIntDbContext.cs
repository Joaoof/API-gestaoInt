using GestaoInt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoInt.Infrastructure.Infrastructure.DataAccess;

public class GestaoIntDbContext: DbContext
{
    public GestaoIntDbContext(DbContextOptions options): base(options)
    {
        
    }
    public DbSet<Movement> Movements { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
