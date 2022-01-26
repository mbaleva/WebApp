namespace WebApp.Recipes.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebApp.Recipes.Application.Commands.Create;
    using WebApp.Recipes.Application.Queries.All;
    using WebApp.Recipes.Application.Queries.GetInfo;
    using WebApp.Recipes.Web.Common;

    [Route("/api/[controller]/[action]")]
    public class RecipesController : ApiController
    {
        private readonly IMediator mediator;

        public RecipesController(
            IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<RecipeInfoOutputModel>> GetInfo(
            RecipeInfoQuery request) =>
                await this.mediator.Send(request).ToActionResult();

        [HttpGet]
        public async Task<ActionResult<AllRecipesQueryOutputModel>> All(
            AllRecipesQuery request) => 
                await this.mediator.Send(request).ToActionResult();

        [HttpPost]
        public async Task<ActionResult<CreateRecipeCommandOutputModel>> Create(
            CreateRecipeCommand request) =>
            await this.mediator.Send(request).ToActionResult();
    }
}
