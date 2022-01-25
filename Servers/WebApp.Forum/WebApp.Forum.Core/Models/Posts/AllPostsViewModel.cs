namespace WebApp.Forum.Models.Posts
{
    using System.Collections.Generic;
    using WebApp.Forum.Models;

    public class AllPostsViewModel : PaginationViewModel
    {
        public List<OnePostViewModel> Posts { get; set; }
    }
}
