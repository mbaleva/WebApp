namespace WebApp.Recipes.Application.Commands.Common
{
    using System.Collections.Generic;
    using WebApp.Common.Application;
    public abstract class BaseRecipeCommand<TCommand> : EntityCommand<int>
        where TCommand : EntityCommand<int>
    {
        public string Name { get; set; }

        public string Instructions { get; set; }

        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public int PortionsCount { get; set; }
        public string Image { get; set; }
        public int Category { get; set; }

        public Dictionary<string, string> Ingredients { get; set; }
    }
}
