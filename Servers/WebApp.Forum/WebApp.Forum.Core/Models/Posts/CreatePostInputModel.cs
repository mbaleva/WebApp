namespace WebApp.Forum.Models.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreatePostInputModel
    {
        [Required]
        [MinLength(6)]
        public string Title { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Content { get; set; }

        public Dictionary<string, string> Categories { get; set; }
    }
}
