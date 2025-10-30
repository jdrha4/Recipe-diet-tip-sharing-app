using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class HomeService : IHomeService
    {
        KuchynkaDbContext _eshopDbContext;
        public HomeService(KuchynkaDbContext kuchynkaDbContext)
        {
            _eshopDbContext = kuchynkaDbContext;
        }

        
    }
}
