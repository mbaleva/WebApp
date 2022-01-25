namespace WebApp.Forum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Content)
                .IsRequired()
                .HasMaxLength(2500);

            builder
                .HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Votes)
                .WithOne(x => x.Comment)
                .HasForeignKey(x => x.CommentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
