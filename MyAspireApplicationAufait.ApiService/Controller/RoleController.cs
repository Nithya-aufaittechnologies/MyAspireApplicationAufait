using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAspireApplicationAufait.ApiService.Application.Interfaces;
using MyAspireApplicationAufait.ApiService.Infrastructure.Entities;
using MyAspireApplicationAufait.AppHost.Domain;
using Microsoft.AspNetCore.Authorization;

namespace MyAspireApplicationAufait.ApiService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public readonly IRoleAppService _roleService;  
      
        public RoleController(ApplicationDbContext context, IRoleAppService roleService)
        {
            _context = context;
            _roleService = roleService; 
        }

        [HttpPost("api/SignIn")]
        public IActionResult SignIn()
        {
            // This will trigger the OpenID Connect authentication flow
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpPost("api/roles")]
        [Authorize]
        public async Task<long> CreateRole(RoleDto role)
        {            
            try
            {
                 var createdRole = await _roleService.CreateRoleAsync(role);
                return createdRole;              
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

    }
}
