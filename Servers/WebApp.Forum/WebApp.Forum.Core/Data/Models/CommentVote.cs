﻿namespace WebApp.Forum.Data.Models
{
    public class CommentVote
    {
        public int Id { get; set; }

        public int CommentId { get; set; }

        public Comment Comment { get; set; }

        public string UserId { get; set; }

        public int Value { get; set; }
    }
}
