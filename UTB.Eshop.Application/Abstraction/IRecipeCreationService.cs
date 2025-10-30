// IRecipeCreationService.cs
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IRecipeCreationService
    {
        void AddRecipe(Recipe recipe);
    }
}