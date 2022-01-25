namespace WebApp.Forum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class PostVoteConfiguration : IEntityTypeConfiguration<PostVote>
    {
        public void Configure(EntityTypeBuilder<PostVote> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Post)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.PostId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
