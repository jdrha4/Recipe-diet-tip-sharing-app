using System;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class TipCustomerService : ITipCustomerService
    {
        Infrastructure.Database.KuchynkaDbContext kuchynkaDbContext;

        public TipCustomerService(Infrastructure.Database.KuchynkaDbContext kuchynkaDbContext)
        {
            this.kuchynkaDbContext = kuchynkaDbContext;
        }

        public IList<Tip> GetTipsForUser(int userId)
        {
            return kuchynkaDbContext.Tips.Where(or => or.UserId == userId)
                                         .ToList();
        }

        public bool Delete(int id)
        {
            var tip = kuchynkaDbContext.Tips.Find(id);
            if (tip == null)
            {
                return false;
            }
            kuchynkaDbContext.Tips.Remove(tip);
            kuchynkaDbContext.SaveChanges();
            return true;
        }

        public Tip GetTipById(int id)
        {
            return kuchynkaDbContext.Tips.Find(id);
        }

        public bool UpdateTip(Tip updatedTip)
        {
            var existingTip = kuchynkaDbContext.Tips.Find(updatedTip.Id);
            if (existingTip == null)
            {
                return false; // Tip not found
            }

            // Update the properties of the existing Tip
            existingTip.Nazov = updatedTip.Nazov;
            existingTip.Popis = updatedTip.Popis;
            

            // Save changes to the database
            kuchynkaDbContext.SaveChanges();
            return true;
        }
    }
}
