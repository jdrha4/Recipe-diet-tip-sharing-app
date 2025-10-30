// RecipeService.cs
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class RecipeService : IRecipeService
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;



        public RecipeService(KuchynkaDbContext dbContext)
        {
            kuchynkaDbContext = dbContext;
        }

        public RecipeViewModel GetAllRecipes()
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = kuchynkaDbContext.Recipes.ToList();
            return viewModel;
        }

        public RecipeViewModel SearchRecipes(string searchTerm)
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = kuchynkaDbContext.Recipes
                .Where(r => r.Nazov.Contains(searchTerm)
                            || r.Popis.Contains(searchTerm)
                            || r.Preferencia.Contains(searchTerm)
                            || r.Obtiaznost.Contains(searchTerm)
                            || r.Ingrediencie.Contains(searchTerm))
                .ToList();
            return viewModel;
        }

        public RecipeViewModel FilterRecipesDifficulty(string obtiaznost)
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = kuchynkaDbContext.Recipes
                .Where(r => r.Obtiaznost == obtiaznost)
                .ToList();
            return viewModel;
        }

        public RecipeViewModel FilterRecipesVegetarian(bool vegetarianskeJedlo)
        {
            RecipeViewModel viewModel = new RecipeViewModel();
            viewModel.Recipes = kuchynkaDbContext.Recipes
                .Where(r => r.VegetarianskeJedlo == vegetarianskeJedlo)
                .ToList();
            return viewModel;
        }

    }
}