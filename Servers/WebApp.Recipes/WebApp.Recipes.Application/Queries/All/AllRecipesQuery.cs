namespace WebApp.Recipes.Application.Queries.All
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class AllRecipesQuery : IRequest<AllRecipesQueryOutputModel>
    {
        public class AllRecipesQueryHandler : IRequestHandler<AllRecipesQuery, AllRecipesQueryOutputModel>
        {
            private readonly IRecipeQueryRepository recipeRepository;

            public AllRecipesQueryHandler(IRecipeQueryRepository repository)
            {
                this.recipeRepository = repository;
            }
            public async Task<AllRecipesQueryOutputModel> Handle(
                AllRecipesQuery request, 
                CancellationToken cancellationToken)
            {
                var output = new AllRecipesQueryOutputModel()
                {
                    Recipes = (IEnumerable<RecipeOutputModel>)this.recipeRepository.GetAllRecipes(),
                };
                return output;
            }
        }
    }
}
