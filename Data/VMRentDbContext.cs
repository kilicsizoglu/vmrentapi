using Microsoft.EntityFrameworkCore;
using vmrentapi.Models;

namespace vmrentapi.Data;

public class VMRentDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;TrustServerCertificate=True;Database=VMRentDB;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<ApiKey> apiKeys;
    public DbSet<User> users;
}