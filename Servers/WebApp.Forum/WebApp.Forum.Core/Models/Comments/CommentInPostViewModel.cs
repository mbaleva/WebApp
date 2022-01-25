namespace Recipes.ViewModels.Forum.Comments
{
    using System;
    public class CommentInPostViewModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public int CountLikes { get; set; }
    }
}
