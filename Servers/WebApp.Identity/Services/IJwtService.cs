namespace WebApp.Identity.Services
{
    using WebApp.Identity.Data.Models;
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser user);
    }
}
