namespace WebApp.Forum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WebApp.Forum.Domain.Models;

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
                .HasMany(x => x.Comments)
                .WithOne()
                .HasForeignKey()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
