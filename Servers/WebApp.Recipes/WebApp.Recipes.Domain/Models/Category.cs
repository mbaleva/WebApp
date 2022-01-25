namespace WebApp.Recipes.Domain.Models
{
    using WebApp.Common.Domain.Models;
    public class Category : Entity<int>
    {
        internal Category(string name) 
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public Category UpdateName(string name) 
        {
            this.Name = name;
            return this;
        }
    }
}
