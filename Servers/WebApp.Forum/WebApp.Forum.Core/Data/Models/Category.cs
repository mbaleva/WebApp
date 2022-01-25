namespace WebApp.Forum.Data.Models
{
    using System.Collections.Generic;
    public class Category
    {
        public Category()
        {
            Posts = new HashSet<Post>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
