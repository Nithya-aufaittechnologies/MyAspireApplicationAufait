using Microsoft.EntityFrameworkCore;

namespace MyAspireApplicationAufait.ApiService
{
    public class Common
    {
        private readonly ApplicationDbContext _dbContext;
        public async Task InsertAsync<T>(T entity) where T : class
        {
            // Add the entity to the DbSet and save changes asynchronously
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
