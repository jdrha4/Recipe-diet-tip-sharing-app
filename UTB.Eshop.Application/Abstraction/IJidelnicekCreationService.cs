// IRecipeCreationService.cs
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IJidelnicekCreationService
    {
        void AddJidelnicek(Jidelnicek jidelnicek);
    }
}