namespace WebApp.Forum.Domain.Models
{
    using WebApp.Common.Domain.Models;
    using WebApp.Common.Domain;
    using System;
    using System.Collections.Generic;
    public class Post : Entity<int>, IAggregateRoot
    {
        internal Post(
            string title,
            string userId,
            string content,
            Category category) 
        {
            this.Title = title;
            this.CreatedOn = DateTime.UtcNow;
            this.UserId = userId;
            this.Content = content;
            this.Category = category;
            this.Comments = new HashSet<Comment>();
        }
        public string Title { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public string UserId { get; private set; }

        public string Content { get; private set; }

        public Category Category { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        public Post AddComment(Comment comment)
        {
            this.Comments.Add(comment);
            return this;
        }

        public Post UpdateContent(string newContent)
        {
            this.Content = Content;
            return this;
        }

        public Post UpdateTitle(string title)
        {
            this.Title = title;
            return this;
        }
    }
}
