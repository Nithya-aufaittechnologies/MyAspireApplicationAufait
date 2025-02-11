using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspireApplicationAufait.ApiService.Application.Interfaces;
using MyAspireApplicationAufait.ApiService.Infrastructure.Entities;
using MyAspireApplicationAufait.AppHost.Domain;

namespace MyAspireApplicationAufait.ApiService.Application.Services
{
    public class RoleAppService:IRoleAppService
    {
       
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<Role> _logger;
        public RoleAppService( ILogger<Role> logger,ApplicationDbContext dbContext)
        {
          
            _logger = logger;
            _dbContext = dbContext;
        }

        
        public async Task<long> CreateRoleAsync(RoleDto input)
        {
            
            var existingRole = await _dbContext.Role.FirstOrDefaultAsync(r => r.RoleName == input.RoleName);
            if (existingRole != null)
            {
               
                return 0;
            }            
            var role = new Role();
            role.RoleName = input.RoleName;
            await _dbContext.Role.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
