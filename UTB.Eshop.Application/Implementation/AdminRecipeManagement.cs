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
    public class AdminRecipeManagement : IAdminRecipeManagement
    {
        private readonly KuchynkaDbContext kuchynkaDbContext;


        public AdminRecipeManagement(KuchynkaDbContext kuchynkaDbContext)
        {
            this.kuchynkaDbContext = kuchynkaDbContext;
        }

        public IList<Recipe> Select()
        {
            return kuchynkaDbContext.Recipes.ToList();
        }

        public bool Delete(int id)
        {
            bool deleted = false;

            Recipe? recipe =
                kuchynkaDbContext.Recipes.FirstOrDefault(
                prod => prod.Id == id);

            if (recipe != null)
            {
                kuchynkaDbContext.Recipes.Remove(recipe);
                kuchynkaDbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }
        public Recipe GetRecipeById(int id)
        {
            return kuchynkaDbContext.Recipes.Find(id);
        }

        public bool UpdateRecipe(Recipe updatedRecipe)
        {
            var existingRecipe = kuchynkaDbContext.Recipes.Find(updatedRecipe.Id);
            if (existingRecipe == null)
            {
                return false;
            }
   
            existingRecipe.Nazov = updatedRecipe.Nazov;
            existingRecipe.Popis = updatedRecipe.Popis;
            existingRecipe.Preferencia = updatedRecipe.Preferencia;
            existingRecipe.Obtiaznost = updatedRecipe.Obtiaznost;
            existingRecipe.Ingrediencie = updatedRecipe.Ingrediencie;
            existingRecipe.VegetarianskeJedlo = updatedRecipe.VegetarianskeJedlo;

            kuchynkaDbContext.SaveChanges();
            return true;
        }

    }
}