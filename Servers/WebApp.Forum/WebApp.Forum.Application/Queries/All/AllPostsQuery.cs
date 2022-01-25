namespace WebApp.Forum.Application.Queries.All
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class AllPostsQuery : IRequest<IEnumerable<PostInCollectionModel>>
    {
        public class AllPostsQueryHandler : IRequestHandler<AllPostsQuery, IEnumerable<PostInCollectionModel>>
        {
            private IPostQueryRepository repository;

            public AllPostsQueryHandler(IPostQueryRepository repository)
            {
                this.repository = repository;
            }

            public async Task<IEnumerable<PostInCollectionModel>> Handle(
                AllPostsQuery request,
                CancellationToken cancellationToken) =>
                    this.repository.AllPosts();
        }
    }
}
