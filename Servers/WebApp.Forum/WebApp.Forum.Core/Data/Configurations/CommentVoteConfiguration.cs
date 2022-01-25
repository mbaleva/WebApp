namespace WebApp.Forum.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class CommentVoteConfiguration : IEntityTypeConfiguration<CommentVote>
    {
        public void Configure(EntityTypeBuilder<CommentVote> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Comment)
                .WithMany(x => x.Votes)
                .HasForeignKey(x => x.CommentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
