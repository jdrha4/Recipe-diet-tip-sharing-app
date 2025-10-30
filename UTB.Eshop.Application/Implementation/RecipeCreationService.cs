// RecipeCreationService.cs
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class RecipeCreationService : IRecipeCreationService
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;

        public RecipeCreationService(KuchynkaDbContext eshopDbContext)
        {
            kuchynkaDbContext = eshopDbContext;
        }

        public void AddRecipe(Recipe recipe)
        {
            if (kuchynkaDbContext != null && recipe.UserId != 0)
            {
                kuchynkaDbContext.Recipes.Add(recipe);
                kuchynkaDbContext.SaveChanges();
            }
        }

    }
}
