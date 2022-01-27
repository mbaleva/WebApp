namespace WebApp.Recipes.Application.Commands.Create
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Common.Application.Contracts;
    using WebApp.Common.Domain;
    using WebApp.Recipes.Application.Commands.Common;
    using WebApp.Recipes.Domain.Factory.Recipes;
    using WebApp.Recipes.Domain.Repositories;

    public class CreateRecipeCommand : BaseRecipeCommand<CreateRecipeCommand>,
        IRequest<CreateRecipeCommandOutputModel>
    {
        public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, CreateRecipeCommandOutputModel>
        {
            private readonly IRecipeDomainRepository repository;
            private readonly ICurrentUser currentUser;
            private readonly IRecipesFactory recipesFactory;

            public CreateRecipeCommandHandler(
                IRecipeDomainRepository repository,
                ICurrentUser currentUser,
                IRecipesFactory recipesFactory)
            {
                this.repository = repository;
                this.currentUser = currentUser;
                this.recipesFactory = recipesFactory;
            }
            public async Task<CreateRecipeCommandOutputModel> Handle(
                CreateRecipeCommand request, 
                CancellationToken cancellationToken)
            {
                var category = this.repository.GetCategory(request.Category);

                var recipe = recipesFactory
                    .WithName(request.Name)
                    .WithInstructions(request.Instructions)
                    .WithPrepTime(request.PreparationTime)
                    .WithCookingTime(request.CookingTime)
                    .WithPortionsCount(request.PortionsCount)
                    .WithImage(request.Image)
                    .WithCategory(category)
                    .WithUser(this.currentUser.UserId)
                    .Build();

                await this.repository.Save(recipe);

                return new CreateRecipeCommandOutputModel(recipe.Id);
            }
        }
    }
}
