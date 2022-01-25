namespace WebApp.Recipes.Web
{
    using FluentValidation.AspNetCore;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;
    using WebApp.Common.Application;
    using WebApp.Common.Application.Contracts;
    using WebApp.Recipes.Web.Services;

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
