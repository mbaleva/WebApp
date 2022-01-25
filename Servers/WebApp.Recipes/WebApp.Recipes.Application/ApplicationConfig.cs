namespace WebApp.Recipes.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using WebApp.Common.Application;
    using Microsoft.Extensions.Configuration;
    using MediatR;
    using System.Reflection;

    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
            => services.AddCommonApplication(configuration)
                .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
