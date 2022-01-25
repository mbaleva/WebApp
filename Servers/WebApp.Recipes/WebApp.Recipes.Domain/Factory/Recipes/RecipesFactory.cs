namespace WebApp.Recipes.Domain.Factory.Recipes
{
    using Models;
    using System.Collections.Generic;
    public class RecipesFactory : IRecipesFactory
    {
        private string name;
        private string instructions;
        private int prepTime;
        private int cookingTime;
        private int portionsCount;
        private Category category;
        private string userId;
        private string imageUrl;
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<Vote> votes = new List<Vote>();

        public IRecipesFactory AddIngredient(string ingredient)
        {
            this.ingredients.Add(new Ingredient(ingredient));
            return this;
        }

        public IRecipesFactory AddVote(
            Recipe recipe,
            string user,
            double value)
        {
            var vote = new Vote(recipe, user, value);
            this.votes.Add(vote);
            return this;
        }

        public Recipe Build()
        {
            return new Recipe(
                this.name,
                this.instructions,
                this.prepTime,
                this.cookingTime,
                this.portionsCount,
                this.category,
                this.userId,
                this.imageUrl);
        }

        public IRecipesFactory WithCategory(Category category)
        {
            this.category = category;
            return this;
        }

        public IRecipesFactory WithCookingTime(int time)
        {
            this.cookingTime = time;
            return this;
        }

        public IRecipesFactory WithImage(string imageUrl)
        {
            this.imageUrl = imageUrl;
            return this;
        }

        public IRecipesFactory WithInstructions(string instructions)
        {
            this.instructions = instructions;
            return this;
        }

        public IRecipesFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IRecipesFactory WithPortionsCount(int portionsCount)
        {
            this.portionsCount = portionsCount;
            return this;
        }

        public IRecipesFactory WithPrepTime(int time)
        {
            this.prepTime = time;
            return this;
        }

        public IRecipesFactory WithUser(string userId)
        {
            this.userId = userId;
            return this;
        }
    }
}
