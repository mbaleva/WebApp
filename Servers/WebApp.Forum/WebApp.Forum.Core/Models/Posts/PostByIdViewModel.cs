namespace WebApp.Forum.Models.Posts
{
    using Ganss.XSS;
    using Recipes.ViewModels.Forum.Comments;
    using System;
    using System.Collections.Generic;
    public class PostByIdViewModel
    {
        public PostByIdViewModel()
        {
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Username { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(Content);

        public string CategoryName { get; set; }

        public int CountLikes { get; set; }

        public ICollection<CommentInPostViewModel> Comments { get; set; }
    }
}
