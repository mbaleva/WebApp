namespace WebApp.Forum.Web
{
    using FluentValidation.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using WebApp.Common.Application;
    using WebApp.Common.Application.Contracts;

    public static class WebConfig
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUserService>()
                .AddControllers()
                .AddFluentValidation(validation => validation
                    .RegisterValidatorsFromAssemblyContaining<Result>())
                .AddNewtonsoftJson();
            return services;
        }
    }
}
