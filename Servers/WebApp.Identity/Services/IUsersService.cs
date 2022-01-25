namespace WebApp.Identity.Services
{
    using WebApp.Identity.ViewModels.Users;
    using System.Threading.Tasks;
    public interface IUsersService
    {
        Task<LoginSuccesModel> Login(LoginInputModel model);

        Task Register(RegisterInputModel model);
    }
}
