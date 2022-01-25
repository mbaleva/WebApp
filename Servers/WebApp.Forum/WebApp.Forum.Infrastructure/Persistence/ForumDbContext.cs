namespace WebApp.Forum.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Reflection;
    using WebApp.Forum.Domain.Models;

    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
        {

        }
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(builder);
        }
    }
}
