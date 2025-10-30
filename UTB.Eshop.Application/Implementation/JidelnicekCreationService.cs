// RecipeCreationService.cs
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class JidelnicekCreationService : IJidelnicekCreationService
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;

        public JidelnicekCreationService(KuchynkaDbContext _kuchynkaDbContext)
        {
            kuchynkaDbContext = _kuchynkaDbContext;
        }

        public void AddJidelnicek(Jidelnicek jidelnicek)
        {
            if (kuchynkaDbContext != null && jidelnicek.UserId != 0)
            {
                kuchynkaDbContext.Jidelnicky.Add(jidelnicek);
                kuchynkaDbContext.SaveChanges();
            }
        }

    }
}
