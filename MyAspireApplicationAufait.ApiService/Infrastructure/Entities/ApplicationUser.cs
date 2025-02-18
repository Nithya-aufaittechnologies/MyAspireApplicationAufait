using static ApplicationDbContext;

namespace MyAspireApplicationAufait.ApiService.Infrastructure.Entities
{
    public class ApplicationUser: CommonEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
