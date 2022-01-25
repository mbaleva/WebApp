namespace WebApp.Common
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Configuration;
    using System.Text;
    using Microsoft.AspNetCore.Http;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreDependencies<TDbContext>(
            this IServiceCollection services,
            IConfiguration config) 
            where TDbContext : DbContext
        {
            services
                .AddDb<TDbContext>(config)
                .AddAppSettings(config)
                .AddJwtAuthentication(config)
                .AddControllers();

            return services;
        }
        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.JwtSecret));

            services
                .Configure<ApplicationSettings>(configuration
                    .GetSection(nameof(ApplicationSettings)));

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
            services.AddHttpContextAccessor();
            return services;
        }

        public static IServiceCollection AddDb<TDbContext>(
            this IServiceCollection services,
            IConfiguration configuration) 
            where TDbContext : DbContext
        {
            services.AddScoped<DbContext, TDbContext>()
                .AddDbContext<TDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
        public static IServiceCollection AddAppSettings(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            services.Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)));

            return services;
        }
    }
}
