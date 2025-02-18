using MyAspireApplicationAufait.ApiService.Infrastructure.Entities;

namespace MyAspireApplicationAufait.ApiService.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}
