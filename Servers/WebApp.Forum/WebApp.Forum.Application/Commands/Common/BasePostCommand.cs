namespace WebApp.Forum.Application.Commands.Common
{
    using System;
    using WebApp.Common.Application;
    using WebApp.Forum.Domain.Models;

    public class BasePostCommand : EntityCommand<int>
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; }
    }
}
