namespace WebApp.Recipes.Application.Queries.GetAllCategories
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Recipes.Application.Commands.Common;

    public class GetAllCategoriesQuery : BaseRecipeCommand<GetAllCategoriesQuery>,
        IRequest<List<GetAllCategoriesOutputModel>>
    {
        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoriesOutputModel>>
        {
            private readonly IRecipeQueryRepository repository;

            public GetAllCategoriesQueryHandler(IRecipeQueryRepository repository)
            {
                this.repository = repository;
            }
            public async Task<List<GetAllCategoriesOutputModel>> Handle(
                GetAllCategoriesQuery request,
                CancellationToken cancellationToken)
            {
                return this.repository.GetAllCategories();
            }
        }
    }
}
