namespace WebApp.Recipes.Domain.Models
{
    using WebApp.Common.Domain.Models;
    public class Ingredient : Entity<int>
    {
        internal Ingredient(string name) 
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public Ingredient UpdateName(string name) 
        {
            this.Name = name;
            return this;
        }
    }
}
