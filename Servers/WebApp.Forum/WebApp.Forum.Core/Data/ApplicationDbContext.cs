namespace WebApp.Forum.Data
{
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;
    using WebApp.Forum.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
