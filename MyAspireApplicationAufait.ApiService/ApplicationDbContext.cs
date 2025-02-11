using Microsoft.EntityFrameworkCore;
using MyAspireApplicationAufait.ApiService.Infrastructure.Entities;

public class ApplicationDbContext : DbContext
{

    public DbSet<UserNew> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<RolePermission> RolePermission { get; set; }
    public DbSet<RoleTest> RoleTest { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
   : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Add custom configurations if necessary.
    }

}

