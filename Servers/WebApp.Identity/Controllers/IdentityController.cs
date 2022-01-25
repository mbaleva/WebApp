namespace WebApp.Identity.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebApp.Identity.Services;
    using WebApp.Identity.ViewModels.Users;

    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IUsersService usersService;

        public IdentityController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }
            await this.usersService.Register(model);
            return this.Ok();
        }
        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginSuccesModel>> Login(LoginInputModel model)
        {
            var data = await this.usersService.Login(model);

            if (data == null)
            {
                return this.BadRequest();
            }
            return data;
        }
    }
}
