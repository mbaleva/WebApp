namespace WebApp.Forum.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Comment
    {
        public Comment()
        {
            Votes = new HashSet<CommentVote>();
        }
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }


        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey("ParentCommentId")]
        public int? ParentCommentId { get; set; }

        public virtual Comment ParentComment { get; set; }

        public ICollection<CommentVote> Votes { get; set; }
    }
}
