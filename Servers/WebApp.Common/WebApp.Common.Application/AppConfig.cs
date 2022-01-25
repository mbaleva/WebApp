namespace WebApp.Common.Application
{
    using System.Reflection;
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    public static class AppConfig
    {
        public static IServiceCollection AddCommonApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services
                .Configure<ApplicationSettings>(
                    configuration.GetSection(nameof(ApplicationSettings)),
                    options => options.BindNonPublicProperties = true)
                .AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}
