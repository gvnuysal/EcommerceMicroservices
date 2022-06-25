using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Teknosol.Services.Catalog.Models;
using Teknosol.Services.Catalog.Services;

namespace Teknosol.Services.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host=CreateHostBuilder(args).Build();
            using var scope=host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            if (!categoryService.GetAllAsync().Result.Items.Any())
            {
                categoryService.CreateAsync(new Category()
                {
                    Name = "Asp.Net Core"
                }).Wait();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
