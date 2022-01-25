namespace WebApp.Recipes.Application.Commands.Create
{
    public class CreateRecipeCommandOutputModel
    {
        public CreateRecipeCommandOutputModel(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}
