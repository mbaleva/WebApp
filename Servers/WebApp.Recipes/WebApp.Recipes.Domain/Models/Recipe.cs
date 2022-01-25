namespace WebApp.Recipes.Domain.Models
{
    using System.Collections.Generic;
    using WebApp.Common.Domain;
    using WebApp.Common.Domain.Models;

    public class Recipe : Entity<int>, IAggregateRoot
    {
        private Recipe() 
        {
        }
        internal Recipe(
            string name,
            string instructions,
            int preparationTime,
            int cookingTime,
            int portionsCount,
            Category category,
            string userId,
            string imageUrl) 
        {
            this.Name = name;
            this.Instructions = instructions;
            this.PreparationTime = preparationTime;
            this.CookingTime = cookingTime;
            this.PortionsCount = portionsCount;
            this.Category = category;
            this.UserId = userId;
            this.ImageUrl = imageUrl;
            this.Ingredients = new List<IngredientToRecipe>();
        }
        public string Name { get; private set; }
        public string Instructions { get; private set; }
        public int PreparationTime { get; private set; }
        public int CookingTime { get; private set; }

        public int PortionsCount { get; private set; }

        public string UserId { get; private set; }
        public Category Category { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<IngredientToRecipe> Ingredients { get; private set; }

        public Recipe AddIngredient(IngredientToRecipe ingredient) 
        {
            this.Ingredients.Add(ingredient);
            return this;
        }
        public Recipe UpdateName(string name) 
        {
            this.Name = name;
            return this;
        }
        public Recipe UpdateInstructions(string instructions)
        {
            this.Instructions = instructions;
            return this;
        }
        public Recipe UpdatePreparationTime(int time)
        {
            this.PreparationTime = time;
            return this;
        }
        public Recipe UpdateCookingTime(int time)
        {
            this.CookingTime = time;
            return this;
        }
        public Recipe UpdatePortionsCount(int count)
        {
            this.PortionsCount = count;
            return this;
        }
    }
}
