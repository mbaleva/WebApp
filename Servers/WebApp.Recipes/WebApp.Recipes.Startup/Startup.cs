namespace WebApp.Recipes.Startup
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Reflection;
    using WebApp.Common;
    using WebApp.Common.Application.Mapping;
    using WebApp.Recipes.Application;
    using WebApp.Recipes.Domain;
    using WebApp.Recipes.Infrastructure;
    using WebApp.Recipes.Web;

    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(options =>
                {
                    options.AddPolicy("Policy", builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
                });
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
                .UseCors("Policy")
                .AddWeb();
        }
    }
}
