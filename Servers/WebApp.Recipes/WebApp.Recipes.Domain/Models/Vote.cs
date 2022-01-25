namespace WebApp.Recipes.Domain.Models
{
    using WebApp.Common.Domain.Models;
    public class Vote : Entity<int>
    {
        internal Vote(
            Recipe recipe,
            string userId,
            double value)
        {
            this.Recipe = recipe;
            this.UserId = userId;
            this.Value = value;
        }
        public virtual Recipe Recipe { get; private set; }
        public string UserId { get; private set; }

        public double Value { get; private set; }

        public Vote UpdateRecipe(Recipe recipe) 
        {
            this.Recipe = recipe;
            return this;
        }

        public Vote UpdateUser(string user)
        {
            this.UserId = user;
            return this;
        }

        public Vote UpdateValue(double value)
        {
            this.Value = value;
            return this;
        }
    }
}
