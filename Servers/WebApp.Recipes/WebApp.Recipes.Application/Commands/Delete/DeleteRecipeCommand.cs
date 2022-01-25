namespace WebApp.Recipes.Application.Commands.Delete
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

    public class DeleteRecipeCommand : BaseRecipeCommand<DeleteRecipeCommand>,
        IRequest<Result>
    {
        public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, Result>
        {
            private readonly ICurrentUser user;
            private IRecipeDomainRepository repository;
            public DeleteRecipeCommandHandler(
                ICurrentUser user,
                IRecipeDomainRepository repo)
            {
                this.user = user;
                this.repository = repo;
            }
            public async Task<Result> Handle(
                DeleteRecipeCommand request,
                CancellationToken cancellationToken)
            {
                var getUserId = this.repository.GetUserId(request.Id);

                if (getUserId != this.user.UserId)
                {
                    return new Result(false, new List<string> { "You cannot delete this recipe." });
                }
                return await this.repository.Delete(request.Id);
            }
        }
    }
}
