namespace WebApp.Forum.Services.Votes
{
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Forum.Data;
    using WebApp.Forum.Data.Models;
    using WebApp.Forum.Models.Votes;

    public class ForumPostVotesService : IForumPostVotesService
    {
        private readonly ApplicationDbContext dbContext;

        public ForumPostVotesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<VoteResponseModel> AddVoteAsync(VoteInputModel model, string userId)
        {
            var vote = dbContext.PostVotes
                .Where(x => x.PostId == model.PostId && x.UserId == userId)
                .FirstOrDefault();

            if (vote != null)
            {
                vote.Value = model.Value;
                await dbContext.SaveChangesAsync();
                return new VoteResponseModel
                {
                    CountLikes =
                    dbContext.PostVotes.Where(x => x.PostId == vote.PostId)
                .Sum(x => x.Value)
                };
            }
            await dbContext.PostVotes.AddAsync(new PostVote
            {
                PostId = model.PostId,
                UserId = userId,
                Value = model.Value,
            });

            await dbContext.SaveChangesAsync();
            return new VoteResponseModel
            {
                CountLikes =
                     dbContext.PostVotes.Where(x => x.PostId == vote.PostId)
                 .Sum(x => x.Value)
            };
        }
    }
}
