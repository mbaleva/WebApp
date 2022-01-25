namespace WebApp.Forum.Services.Votes
{
    using System.Threading.Tasks;
    using WebApp.Forum.Models.Votes;

    public interface IForumPostVotesService
    {
        Task<VoteResponseModel> AddVoteAsync(VoteInputModel model, string userId);
    }
}
