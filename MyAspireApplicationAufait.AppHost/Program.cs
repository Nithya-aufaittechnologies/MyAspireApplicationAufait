using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MyAspireApplicationAufait.AppHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                  //  webBuilder.UseStartup<Startup>(); // For ASP.NET Core 3.x and earlier (using Startup.cs)
                    // OR
                    // webBuilder.UseUrls("http://localhost:5000"); // You can add custom configuration
                });
    }
}
