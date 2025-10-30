// RecipeService.cs
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class JidelnicekService : IJidelnicekService
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;



        public JidelnicekService(KuchynkaDbContext dbContext)
        {
            kuchynkaDbContext = dbContext;
        }

        public JidelnickyViewModel GetAllJidelnicky()
        {
            JidelnickyViewModel viewModel = new JidelnickyViewModel();
            viewModel.Jidelnicky = kuchynkaDbContext.Jidelnicky.ToList();
            return viewModel;
        }

        public JidelnickyViewModel SearchJidelnicky(string searchTerm)
        {
            JidelnickyViewModel viewModel = new JidelnickyViewModel();
            viewModel.Jidelnicky = kuchynkaDbContext.Jidelnicky
                .Where(r => r.Nazov.Contains(searchTerm)
                            || r.Popis.Contains(searchTerm)
                            || r.Preferencia.Contains(searchTerm)
                            || r.Ranajky.Contains(searchTerm)
                            || r.Vecera.Contains(searchTerm)
                            || r.Obed.Contains(searchTerm))
                .ToList();
            return viewModel;
        }

    }
}