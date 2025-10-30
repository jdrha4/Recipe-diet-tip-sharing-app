using System;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class JidelnicekCustomerService : IJidelnicekCustomerService
    {
        Infrastructure.Database.KuchynkaDbContext kuchynkaDbContext;

        public JidelnicekCustomerService(Infrastructure.Database.KuchynkaDbContext kuchynkaDbContext)
        {
            this.kuchynkaDbContext = kuchynkaDbContext;
        }

        public IList<Jidelnicek> GetJidelnickyForUser(int userId)
        {
            return kuchynkaDbContext.Jidelnicky.Where(or => or.UserId == userId)
                                         .ToList();
        }

        public bool Delete(int id)
        {
            var jidelnicek = kuchynkaDbContext.Jidelnicky.Find(id);
            if (jidelnicek == null)
            {
                return false;
            }
            kuchynkaDbContext.Jidelnicky.Remove(jidelnicek);
            kuchynkaDbContext.SaveChanges();
            return true;
        }

        public Jidelnicek GetJidelnicekById(int id)
        {
            return kuchynkaDbContext.Jidelnicky.Find(id);
        }

        public bool UpdateJidelnicek(Jidelnicek updatedJidelnicek)
        {
            var existingJidelnicek = kuchynkaDbContext.Jidelnicky.Find(updatedJidelnicek.Id);
            if (existingJidelnicek == null)
            {
                return false; // Recipe not found
            }

            // Update the properties of the existing recipe
            existingJidelnicek.Nazov = updatedJidelnicek.Nazov;
            existingJidelnicek.Popis = updatedJidelnicek.Popis;
            existingJidelnicek.Preferencia = updatedJidelnicek.Preferencia;
            existingJidelnicek.Ranajky = updatedJidelnicek.Ranajky;
            existingJidelnicek.Obed = updatedJidelnicek.Obed;
            existingJidelnicek.Vecera= updatedJidelnicek.Vecera;

            // Save changes to the database
            kuchynkaDbContext.SaveChanges();
            return true;
        }
    }
}
