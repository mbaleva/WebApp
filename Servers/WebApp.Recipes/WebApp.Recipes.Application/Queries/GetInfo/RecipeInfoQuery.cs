namespace WebApp.Recipes.Application.Queries.GetInfo
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Common.Application;
    using WebApp.Recipes.Application.Commands.Common;

    public class RecipeInfoQuery : BaseRecipeCommand<RecipeInfoQuery>, IRequest<RecipeInfoOutputModel>
    {
        public class RecipeInfoQueryHandler : IRequestHandler<RecipeInfoQuery, RecipeInfoOutputModel>
        {
            private readonly IRecipeQueryRepository recipeRepository;

            public RecipeInfoQueryHandler(
                IRecipeQueryRepository recipeRepository)
            {
                this.recipeRepository = recipeRepository;
            }
            public async Task<RecipeInfoOutputModel> Handle(
                RecipeInfoQuery request,
                CancellationToken cancellationToken) => 
                await this.recipeRepository.GetDetails(request.Id);
        }
    }
}
