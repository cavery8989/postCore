using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Core.Models.Database;

namespace Core
{
    public class Startup
    {
        public IConfigurationRoot Configuration {get;}
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, 
                reloadOnChange: true)
                .AddEnvironmentVariables();
                Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration["DbContextSettings:ConnectionString"];

            services.AddDbContext<DatabaseContext>(opts => opts.UseNpgsql(connectionString));
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}