// RecipeService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class AdminJidelnicekManagement : IAdminJidelnicekManagement
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;


        public AdminJidelnicekManagement(KuchynkaDbContext kuchynkaDbContext)
        {
            this.kuchynkaDbContext = kuchynkaDbContext;
        }

        public IList<Jidelnicek> Select()
        {
            return kuchynkaDbContext.Jidelnicky.ToList();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Jidelnicek? jidelnicek =
                kuchynkaDbContext.Jidelnicky.FirstOrDefault(
                prod => prod.Id == id);

            if (jidelnicek != null)
            {
                kuchynkaDbContext.Jidelnicky.Remove(jidelnicek);
                kuchynkaDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
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
                return false;
            }

            existingJidelnicek.Nazov = updatedJidelnicek.Nazov;
            existingJidelnicek.Popis = updatedJidelnicek.Popis;
            existingJidelnicek.Preferencia = updatedJidelnicek.Preferencia;
            existingJidelnicek.Ranajky = updatedJidelnicek.Ranajky;
            existingJidelnicek.Obed = updatedJidelnicek.Obed;
            existingJidelnicek.Vecera = updatedJidelnicek.Vecera;

            kuchynkaDbContext.SaveChanges();
            return true;
        }

    }
}