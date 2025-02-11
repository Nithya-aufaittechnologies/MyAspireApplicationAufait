using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using MyAspireApplicationAufait.ApiService.Application.Interfaces;
using MyAspireApplicationAufait.ApiService.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Register ApplicationDbContext with DI container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
builder.Services.AddScoped<IRoleAppService, RoleAppService>();
builder.Services.AddControllers();
builder.Services.AddLogging(builder => builder.AddConsole());
// Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddMicrosoftIdentityWebApp(options =>
               {
                   options.ClientId = builder.Configuration["AzureAdB2C:ClientId"];
                   options.TenantId = builder.Configuration["AzureAdB2C:TenantId"];
                   options.ClientSecret = builder.Configuration["AzureAdB2C:ClientSecret"];
                   options.Authority = builder.Configuration["AzureAdB2C:Authority"];
                   options.CallbackPath = builder.Configuration["AzureAdB2C:CallbackPath"];
                   options.SaveTokens = true;
               });
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
// Use Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Make Swagger UI available at the root
    });
}

app.UseRouting();
app.MapControllers();
app.Run();
