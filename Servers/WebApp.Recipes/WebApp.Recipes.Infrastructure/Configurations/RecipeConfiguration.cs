namespace WebApp.Recipes.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WebApp.Recipes.Domain.Models;

    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Instructions)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .Property(x => x.PortionsCount)
                .IsRequired();


            builder
                .HasMany(x => x.Ingredients)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
