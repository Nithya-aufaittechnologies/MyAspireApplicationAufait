namespace MyAspireApplicationAufait.ApiService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register Swagger services
            services.AddSwaggerGen();
        }
    }
}
