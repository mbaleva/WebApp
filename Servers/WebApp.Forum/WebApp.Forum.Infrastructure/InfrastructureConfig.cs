namespace WebApp.Forum.Infrastructure
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Text;
    using WebApp.Common.Application;
    using WebApp.Common.Domain;
    using WebApp.Forum.Infrastructure.Persistence;

    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructure(
               this IServiceCollection services,
               IConfiguration configuration)
        {
            services
                .AddDatabase(configuration)
                .AddRepositories()
                .AddJwt(configuration);
            return services;
        }
        private static IServiceCollection AddJwt(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            return services;
        }
        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .AddDbContext<ForumDbContext>(options => options
                    .UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        sqlServer => sqlServer
                            .MigrationsAssembly(typeof(ForumDbContext).Assembly.FullName)));

        private static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IDomainRepository<>))
                        .AssignableTo(typeof(IQueryRepository<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
        public static IApplicationBuilder AddWeb(
            this IApplicationBuilder app) =>
                app.UseHttpsRedirection()
                    .UseRouting()
                    .UseAuthentication()
                    .UseAuthorization()
                    .UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
    }
}
