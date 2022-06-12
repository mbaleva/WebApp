namespace WebApp.Forum.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApp.Common.Infrastructure;
    using WebApp.Forum.Application.Commands.Common;
    using WebApp.Forum.Application.Commands.Create;
    using WebApp.Forum.Application.Queries.All;

    [Route("/api/[controller]/[action]")]
    public class ForumController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<BasePostOutputModel>> Create(
            [FromBody] CreatePostCommand request)
            => await this.Send(request);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostInCollectionModel>>> GetAll(
            [FromBody] AllPostsQuery request)
            => await this.Send(request);
    }
}
