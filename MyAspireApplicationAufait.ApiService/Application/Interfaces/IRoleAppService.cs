using Microsoft.AspNetCore.Mvc;
using MyAspireApplicationAufait.AppHost.Domain;

namespace MyAspireApplicationAufait.ApiService.Application.Interfaces
{
    public interface IRoleAppService
    {
        
        Task<long> CreateRoleAsync(RoleDto input);
    }
}
