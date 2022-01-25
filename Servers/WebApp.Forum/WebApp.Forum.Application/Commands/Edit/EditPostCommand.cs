namespace WebApp.Forum.Application.Commands.Edit
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using WebApp.Forum.Application.Commands.Common;
    using WebApp.Forum.Domain;

    public class EditPostCommand : BasePostCommand, IRequest<BasePostOutputModel>
    {
        public class EditPostCommandHandler : IRequestHandler<EditPostCommand, BasePostOutputModel>
        {
            private IDomainPostRepository repository;

            public EditPostCommandHandler(IDomainPostRepository repository)
            {
                this.repository = repository;
            }

            public async Task<BasePostOutputModel> Handle(
                EditPostCommand request, 
                CancellationToken cancellationToken)
            {
                var post = await this.repository.GetById(request.Id);

                post
                    .UpdateTitle(request.Title)
                    .UpdateContent(request.Content);

                return new BasePostOutputModel { Id = post.Id };
            }
        }
    }
}
