namespace WebApp.Forum.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using WebApp.Common.Application.Mapping;
    using WebApp.Forum.Application;
    using WebApp.Forum.Infrastructure;
    using WebApp.Forum.Domain;
    using WebApp.Forum.Web;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("Policy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services
                .AddDomain()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddWebComponents();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(
               Assembly.GetAssembly(typeof(ApplicationConfig)),
               Assembly.GetAssembly(typeof(InfrastructureConfig)),
               Assembly.GetAssembly(typeof(DomainConfig)));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app
                .AddWeb()
                .UseCors("Policy");
        }
    }
}
