namespace WebApp.Recipes.Domain.Repositories
{
    using System.Threading.Tasks;
    using WebApp.Common.Domain;
    using WebApp.Recipes.Domain.Models;

    public interface IRecipeDomainRepository : IDomainRepository<Recipe>
    {
        Category GetCategory(int id);

        Task<bool> Delete(int id);

        string GetUserId(int id);

        Recipe FindById(int id);
    }
}
