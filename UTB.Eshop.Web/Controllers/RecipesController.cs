// RecipesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity;
using UTB.Eshop.Infrastructure.Identity.Enums;


public class RecipesController : Controller
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
    }


    public IActionResult Index(string searchTerm)
    {
        RecipeViewModel viewModel;

        if (string.IsNullOrEmpty(searchTerm))
        {
            viewModel = _recipeService.GetAllRecipes();
        }
        else
        {
            viewModel = _recipeService.SearchRecipes(searchTerm);
        }

        return View(viewModel);
    }

    public IActionResult FilterDifficulty(string obtiaznost)
    {
        RecipeViewModel viewModel = _recipeService.FilterRecipesDifficulty(obtiaznost);
        return View("Index", viewModel);
    }

    public IActionResult FilterVegetarian(bool vegetarianskeJedlo)
    {
        RecipeViewModel viewModel = _recipeService.FilterRecipesVegetarian(vegetarianskeJedlo);
        return View("Index", viewModel);
    }
    
    
}
