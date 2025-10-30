// IRecipeService.cs
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface ITipService
    {
        TipViewModel GetAllTips();
        TipViewModel SearchTips(string searchTerm);
      
    }
}