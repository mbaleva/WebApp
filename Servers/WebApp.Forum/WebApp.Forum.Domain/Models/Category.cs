namespace WebApp.Forum.Domain.Models
{
    using WebApp.Common.Domain.Models;
    public class Category :Entity<int>
    {
        internal Category(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        public string Name { get; private set; }

        public string Description { get; private set; }

        public Category UpdateName(string name) 
        {
            this.Name = name;
            return this;
        }
        public Category UpdateDescription(string description)
        {
            this.Description = description;
            return this;
        }
    }
}
