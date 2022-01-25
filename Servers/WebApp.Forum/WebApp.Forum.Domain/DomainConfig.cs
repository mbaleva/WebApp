namespace WebApp.Forum.Domain
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using WebApp.Common.Domain;

    public static class DomainConfig
    {
        public static IServiceCollection AddDomain(
            this IServiceCollection services) 
        {
            services
               .Scan(x =>
                   x.FromAssemblies(Assembly.GetExecutingAssembly())
                   .AddClasses(x => x.AssignableTo(typeof(IFactory<>)))
                   .AsMatchingInterface()
                   .WithTransientLifetime());

            return services;
        }
    }
}
