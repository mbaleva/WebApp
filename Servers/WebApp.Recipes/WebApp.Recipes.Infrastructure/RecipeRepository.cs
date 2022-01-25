namespace WebApp.Recipes.Infrastructure
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WebApp.Common.Application.Mapping;
    using WebApp.Common.Infrastructure.Persistence;
    using WebApp.Recipes.Application;
    using WebApp.Recipes.Application.Queries.All;
    using WebApp.Recipes.Application.Queries.GetInfo;
    using WebApp.Recipes.Application.Queries.GetMyRecipes;
    using WebApp.Recipes.Domain.Models;
    using WebApp.Recipes.Domain.Repositories;
    using WebApp.Recipes.Infrastructure.Persistence;

    internal class RecipeRepository : DataRepository<RecipesDbContext, Recipe>,
        IRecipeDomainRepository,
        IRecipeQueryRepository
    {
        private readonly IMapper mapper;

        public RecipeRepository(RecipesDbContext context, 
            IMapper mapper)
            :base(context)
        {
            this.mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            var entity = await this.Data.Recipes.FindAsync(id);

            if (entity == null)
            {
                return false;
            }
            this.Data.Recipes.Remove(entity);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public Recipe FindById(int id) => this.Data.Recipes.Find(id);

        public Category GetCategory(int id)
        {
            return this.Data.Recipes.Where(x => x.Id == id)
                .Include(x => x.Category)
                .FirstOrDefault()
                .Category;
        }

        public async Task<RecipeInfoOutputModel> GetDetails(int id)
        {
            return this.Data.Recipes.Where(x => x.Id == id)
                .To<RecipeInfoOutputModel>()
                .FirstOrDefault();
        }

        public async Task<MyRecipesOutputModel> GetRecipesByUser(string userId)
        {

            return new MyRecipesOutputModel()
            {
                MyRecipes = this.Data.Recipes.Where(x => x.UserId == userId)
                    .Select(x => new RecipeOutputModel()
                    {
                        Id = x.Id,
                        Instructions = x.Instructions,
                        Name = x.Name,
                        ImageUrl = x.ImageUrl,
                    })
            };
            
        }

        public string GetUserId(int id)
        {
            return this.Data.Recipes.Where(x => x.Id == id)
                .FirstOrDefault()
                .UserId;
        }

        public IEnumerable<RecipeOutputModel> GetAllRecipes()
        {
            return this.Data.Recipes
                .Where(x => x.Id != 0)
               .To<RecipeOutputModel>()
               .ToList();
        }
    }
}
