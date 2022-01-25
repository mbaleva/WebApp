namespace WebApp.Forum.Domain.Models
{
    using System.Collections.Generic;
    using WebApp.Common.Domain.Models;
    using System;
    public class Comment : Entity<int>
    {
        internal Comment(
            string content,
            string userId,
            Post post)
        {
            this.CreatedOn = DateTime.UtcNow;
            this.Content = content;
            this.UserId = userId;
            this.Comments = new HashSet<Comment>();
        }

        public DateTime CreatedOn { get; private set; }

        public string Content { get; private set; }

        public string UserId { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        public Comment AddComment(Comment comment) 
        {
            this.Comments.Add(comment);
            return this;
        }
        public Comment UpdateContent(string newContent) 
        {
            this.Content = Content;
            return this;
        }
    }
}
