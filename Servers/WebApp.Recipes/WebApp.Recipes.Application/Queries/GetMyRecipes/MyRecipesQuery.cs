namespace WebApp.Recipes.Application.Queries.GetMyRecipes
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Common.Application;
    using WebApp.Common.Application.Contracts;

    public class MyRecipesQuery : EntityCommand<int>,
        IRequest<MyRecipesOutputModel>
    {
        public class MyRecipesQueryHandler : IRequestHandler<MyRecipesQuery, MyRecipesOutputModel>
        {
            private ICurrentUser user;
            private IRecipeQueryRepository repository;
            public MyRecipesQueryHandler(
                ICurrentUser user,
                IRecipeQueryRepository repository)
            {
                this.user = user;
                this.repository = repository;
            }
            public Task<MyRecipesOutputModel> Handle(
                MyRecipesQuery request,
                CancellationToken cancellationToken) =>
                    this.repository.GetRecipesByUser(user.UserId);
        }
    }
}
