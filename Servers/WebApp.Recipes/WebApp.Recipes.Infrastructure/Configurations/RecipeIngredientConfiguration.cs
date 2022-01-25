namespace WebApp.Recipes.Infrastructure.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WebApp.Recipes.Domain.Models;

    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<IngredientToRecipe>
    {
        public void Configure(EntityTypeBuilder<IngredientToRecipe> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Quantity)
                .HasMaxLength(50)
                .IsRequired(false);

            builder
                .HasOne(x => x.Recipe)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Ingredient)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
