using Microsoft.EntityFrameworkCore;

namespace EFCore_CodeFirst_Test_Example.Infrastructure;

public class DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration config) : DbContext(options)
{
    // [KOLOKWIUM]: Tutaj wpiszesz public DbSet<NazwaEncji> NazwaTabeli { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Zaczytanie schematu "test-example" z appsettings.json
        modelBuilder.HasDefaultSchema(config["DB:DefaultSchema"]);
        
        // [KOLOKWIUM]: Tutaj wpiszesz reguły Fluent API, np. modelBuilder.Entity<...>(...)
    }
}