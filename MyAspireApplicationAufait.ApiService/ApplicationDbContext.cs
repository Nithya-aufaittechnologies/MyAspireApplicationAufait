using Microsoft.EntityFrameworkCore;
using MyAspireApplicationAufait.ApiService.Infrastructure.Entities;

public class ApplicationDbContext : DbContext
{

    public DbSet<UserNew> Users { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<RolePermission> RolePermission { get; set; }
    public DbSet<RoleTest> RoleTest { get; set; }
    public DbSet<RoleTestDI> RoleTestDI { get; set; }

    public DbSet<ApplicationUser> ApplicationUser { get; set; }
    
    //public DbSet<CommonEntitiesTestDI> CommonEntitiesTestDI { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
   : base(options) { }
    public async Task<int> InsertAndGetIdAsync<T>(T entity) where T : class
    {      
        await Set<T>().AddAsync(entity);        
        await SaveChangesAsync();       
        return (int)typeof(T).GetProperty("Id").GetValue(entity);
    }
    public async Task InsertAsync<T>(T entity) where T : class
    {        
        await Set<T>().AddAsync(entity);       
        await SaveChangesAsync();
    }
    public async Task UpdateAsync<T>(T entity) where T : class
    {
        // Mark the entity as modified so EF will update it
        Set<T>().Update(entity);
        // Save changes to the database asynchronously
        await SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }

    public class CommonEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}

