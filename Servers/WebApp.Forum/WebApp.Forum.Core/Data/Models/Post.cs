namespace WebApp.Forum.Data.Models
{
    using System;
    using System.Collections.Generic;
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            Votes = new HashSet<PostVote>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<PostVote> Votes { get; set; }
    }
}
