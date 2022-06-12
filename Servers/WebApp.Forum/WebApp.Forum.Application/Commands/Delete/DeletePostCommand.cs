namespace WebApp.Forum.Application.Commands.Delete
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Common.Application;
    using WebApp.Forum.Application.Commands.Common;
    using WebApp.Forum.Domain;

    public class DeletePostCommand : BasePostCommand, IRequest<Result>
    {
        public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result>
        {
            private IPostDomainRepository repository;

            public DeletePostCommandHandler(
                IPostDomainRepository repository)
            {
                this.repository = repository;
            }

            public async Task<Result> Handle(
                DeletePostCommand request,
                CancellationToken cancellationToken)
            {
                await this.repository.Delete(request.Id);
                return Result.Success;
            }
        }
    }
}
