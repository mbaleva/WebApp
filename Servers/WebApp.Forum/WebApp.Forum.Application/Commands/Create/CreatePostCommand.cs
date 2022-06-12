namespace WebApp.Forum.Application.Commands.Create
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Common.Application;
    using WebApp.Common.Application.Contracts;
    using WebApp.Forum.Application.Commands.Common;
    using WebApp.Forum.Domain;
    using WebApp.Forum.Domain.Factories;

    public class CreatePostCommand : BasePostCommand, IRequest<BasePostOutputModel>
    {
        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, BasePostOutputModel>
        {
            private IPostFactory factory;
            private ICurrentUser currentUser;
            private IPostDomainRepository repository;
            public CreatePostCommandHandler(
                IPostFactory factory,
                ICurrentUser user,
                IPostDomainRepository repository)
            {
                this.factory = factory;
                this.currentUser = user;
                this.repository = repository;
            }
            public async Task<BasePostOutputModel> Handle(
                CreatePostCommand request,
                CancellationToken cancellationToken)
            {
                var category = this.repository.GetCategory(request.CategoryId);

                var post = factory
                    .WithTitle(request.Title)
                    .WithUser(this.currentUser.UserId)
                    .WithContent(request.Content)
                    .WithCategory(category)
                    .Build();

                await this.repository.Save(post);

                return new BasePostOutputModel { Id = post.Id };
            }
        }
    }
}
