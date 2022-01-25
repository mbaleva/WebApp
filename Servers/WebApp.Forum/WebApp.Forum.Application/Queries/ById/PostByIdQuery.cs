namespace WebApp.Forum.Application.Queries.ById
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Forum.Application.Commands.Common;

    public class PostByIdQuery : BasePostCommand, IRequest<PostByIdOutputModel>
    {
        public class PostByIdQueryHandler : IRequestHandler<PostByIdQuery, PostByIdOutputModel>
        {
            private readonly IPostQueryRepository repository;

            public PostByIdQueryHandler(IPostQueryRepository repository)
            {
                this.repository = repository;
            }

            public Task<PostByIdOutputModel> Handle(
                PostByIdQuery request,
                CancellationToken cancellationToken)
            {
                return this.repository.ById(request.Id);
            }
        }
    }
}
