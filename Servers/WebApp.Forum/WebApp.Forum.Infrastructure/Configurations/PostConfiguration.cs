namespace WebApp.Forum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WebApp.Forum.Domain.Models;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.Content)
                .HasMaxLength(2500)
                .IsRequired();

            builder
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey()
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Comments)
                .WithOne()
                .HasForeignKey()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
