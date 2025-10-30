// TipCreationService.cs
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class TipCreationService : ITipCreationService
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;

        public TipCreationService(KuchynkaDbContext eshopDbContext)
        {
            kuchynkaDbContext = eshopDbContext;
        }

        public void AddTip(Tip tip)
        {
            if (kuchynkaDbContext != null && tip.UserId != 0)
            {
                kuchynkaDbContext.Tips.Add(tip);
                kuchynkaDbContext.SaveChanges();
            }
        }

    }
}
