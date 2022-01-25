namespace WebApp.Recipes.Application.Commands.Edit
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Common.Application;
    using WebApp.Common.Application.Contracts;
    using WebApp.Recipes.Application.Commands.Common;
    using WebApp.Recipes.Domain.Repositories;

    public class EditRecipeCommand : BaseRecipeCommand<EditRecipeCommand>,
        IRequest<Result>
    {
        public class EditRecipeCommandHandler : IRequestHandler<EditRecipeCommand, Result>
        {
            private ICurrentUser user;
            private IRecipeDomainRepository repository;

            public EditRecipeCommandHandler(
                ICurrentUser user,
                IRecipeDomainRepository repository)
            {
                this.user = user;
                this.repository = repository;
            }
            public async Task<Result> Handle(
                EditRecipeCommand request,
                CancellationToken cancellationToken)
            {
                var recipe = this.repository.FindById(request.Id);

                if (recipe == null)
                {
                    return Result.Failure(new List<string> { "You cannot edit recipe which doesn't exist" });
                }
                recipe
                    .UpdateName(request.Name)
                    .UpdateInstructions(request.Instructions)
                    .UpdateCookingTime(request.CookingTime)
                    .UpdatePortionsCount(request.PortionsCount)
                    .UpdatePreparationTime(request.PreparationTime);

                return Result.Success;
            }
        }
    }
}
