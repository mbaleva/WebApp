namespace WebApp.Identity
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Text;
    using WebApp.Common;
    using WebApp.Identity.Data;
    using WebApp.Identity.Data.Models;
    using WebApp.Identity.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services
                 .AddIdentity<ApplicationUser, IdentityRole>(options =>
                 {
                     options.Password.RequiredLength = 6;
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
                 })
                .AddEntityFrameworkStores<ApplicationDbContext>();


                services
                .AddCoreDependencies<ApplicationDbContext>(this.Configuration)
                .AddCors(options => options.AddPolicy("Policy", builder =>
                {
                     builder.WithOrigins("http://localhost:3000")
                         .AllowAnyMethod()
                         .AllowAnyHeader();
                }))
                .AddTransient<IJwtService, JwtService>()
                .AddTransient<IUsersService, UsersService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app
                .AddWeb()
                .UseCors("Policy")
                .MapEndpoints();
        }
    }
}
