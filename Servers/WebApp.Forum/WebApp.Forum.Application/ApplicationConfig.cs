namespace WebApp.Forum.Application
{
    using MediatR;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using WebApp.Common.Application;

    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration) =>
                services.AddCommonApplication(configuration)
                     .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
