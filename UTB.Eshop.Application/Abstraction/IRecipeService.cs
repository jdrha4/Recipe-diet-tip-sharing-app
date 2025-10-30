// IRecipeService.cs
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IRecipeService
    {
        RecipeViewModel GetAllRecipes();
        RecipeViewModel SearchRecipes(string searchTerm);
        RecipeViewModel FilterRecipesDifficulty(string obtiaznost);
        RecipeViewModel FilterRecipesVegetarian(bool vegetarianskeJedlo);

    }
}