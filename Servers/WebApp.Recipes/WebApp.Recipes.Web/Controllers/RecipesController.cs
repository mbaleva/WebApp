namespace WebApp.Recipes.Web.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApp.Recipes.Application.Commands.Create;
    using WebApp.Recipes.Application.Queries.All;
    using WebApp.Recipes.Application.Queries.GetAllCategories;
    using WebApp.Recipes.Application.Queries.GetInfo;
    using WebApp.Common.Infrastructure;

    [Route("/api/[controller]/[action]")]
    public class RecipesController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<RecipeInfoOutputModel>> GetInfo(
            RecipeInfoQuery request) =>
                await this.Send(request);

        [HttpGet]
        public async Task<ActionResult<AllRecipesQueryOutputModel>> All(
            AllRecipesQuery request) =>
                await this.Send(request);

        [HttpPost]
        public async Task<ActionResult<CreateRecipeCommandOutputModel>> Create(
            [FromBody]CreateRecipeCommand request) =>
            await this.Send(request);

        [HttpGet]
        public async Task<ActionResult<List<GetAllCategoriesOutputModel>>> GetAllCategories(
            GetAllCategoriesQuery request) =>
            await this.Send(request);
    }
}
