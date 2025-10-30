// Tipservice.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class AdminTipManagement : IAdminTipManagement
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;


        public AdminTipManagement(KuchynkaDbContext kuchynkaDbContext)
        {
            this.kuchynkaDbContext = kuchynkaDbContext;
        }

        public IList<Tip> Select()
        {
            return kuchynkaDbContext.Tips.ToList();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Tip? tip =
                kuchynkaDbContext.Tips.FirstOrDefault(
                prod => prod.Id == id);

            if (tip != null)
            {
                kuchynkaDbContext.Tips.Remove(tip);
                kuchynkaDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
        
    }
}