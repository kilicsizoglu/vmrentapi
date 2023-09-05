using Microsoft.EntityFrameworkCore;
using vmrentapi.Models;

namespace vmrentapi.Data;

public class VMRentDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;database=VMRentDB;UID=sa;PWD=0900tgbyhn.,!;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<ApiKey> apiKeys;
    public DbSet<User> users;
}