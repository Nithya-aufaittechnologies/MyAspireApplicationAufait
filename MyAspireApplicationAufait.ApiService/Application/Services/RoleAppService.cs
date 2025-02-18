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
using Microsoft.Graph;

namespace MyAspireApplicationAufait.ApiService.Application.Services
{
    public class RoleAppService : IRoleAppService
    {

        private readonly ApplicationDbContext _dbContext;

        private readonly ILogger<Role> _logger;
        public RoleAppService(ILogger<Role> logger, ApplicationDbContext dbContext)
        {

            _logger = logger;
            _dbContext = dbContext;
        }


        public async Task<long> CreateRoleAsync(RoleDto input)
        {
            long id = 0;
            var existingRole = await _dbContext.ApplicationUser.FirstOrDefaultAsync(r => r.Username == input.RoleName);
            if (existingRole != null)
            {

                return id;
            }
            var role = new RoleTestDI();
            role.CreatedDate =( DateTime) input.CreatedAt;
            role.RoleName = input.RoleName;
            id=await _dbContext.InsertAndGetIdAsync(role);
            await _dbContext.SaveChangesAsync();
            return id;
        }

        public async Task<long> UpdateRoleAsync(RoleDto input)
        {         
            
            var role = new Role();
            role.RoleName = input.RoleName;
            await _dbContext.UpdateAsync(role);
            await _dbContext.SaveChangesAsync();
            return input.Id;
        }
    }
}
