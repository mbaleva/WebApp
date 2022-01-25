namespace WebApp.Common
{
    using Microsoft.AspNetCore.Builder;
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddWeb(
            this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
        public static IApplicationBuilder MapEndpoints(
            this IApplicationBuilder app) 
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            return app;
        }
    }
}
