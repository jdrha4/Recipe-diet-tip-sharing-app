// Tipservice.cs
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class TipService : ITipService
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;


        public TipService(KuchynkaDbContext dbContext)
        {
            kuchynkaDbContext = dbContext;
        }

        public TipViewModel GetAllTips()
        {
            TipViewModel viewModel = new TipViewModel();
            viewModel.Tips = kuchynkaDbContext.Tips.ToList();
            return viewModel;
        }

        public TipViewModel SearchTips(string searchTerm)
        {
            TipViewModel viewModel = new TipViewModel();
            viewModel.Tips = kuchynkaDbContext.Tips
                .Where(r => r.Nazov.Contains(searchTerm)
                            || r.Popis.Contains(searchTerm)
                            )
                .ToList();
            return viewModel;
        }

        
    }
}