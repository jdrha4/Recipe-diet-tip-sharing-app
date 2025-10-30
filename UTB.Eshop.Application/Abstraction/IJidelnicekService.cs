// IRecipeService.cs
using UTB.Eshop.Application.ViewModels;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IJidelnicekService
    {
        JidelnickyViewModel GetAllJidelnicky();
        JidelnickyViewModel SearchJidelnicky(string searchTerm);
       

    }
}