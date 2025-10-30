using System;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;

namespace UTB.Eshop.Application.Implementation
{
    public class RecipeCustomerService : IRecipeCustomerService
    {
        Infrastructure.Database.KuchynkaDbContext kuchynkaDbContext;

        public RecipeCustomerService(Infrastructure.Database.KuchynkaDbContext kuchynkaDbContext)
        {
            this.kuchynkaDbContext = kuchynkaDbContext;
        }

        public IList<Recipe> GetRecipesForUser(int userId)
        {
            return kuchynkaDbContext.Recipes.Where(or => or.UserId == userId)
                                         .ToList();
        }

        public bool Delete(int id)
        {
            var recipe = kuchynkaDbContext.Recipes.Find(id);
            if (recipe == null)
            {
                return false;
            }
            kuchynkaDbContext.Recipes.Remove(recipe);
            kuchynkaDbContext.SaveChanges();
            return true;
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
                return false; // Recipe not found
            }

            // Update the properties of the existing recipe
            existingRecipe.Nazov = updatedRecipe.Nazov;
            existingRecipe.Popis = updatedRecipe.Popis;
            existingRecipe.Preferencia = updatedRecipe.Preferencia;
            existingRecipe.Obtiaznost = updatedRecipe.Obtiaznost;
            existingRecipe.Ingrediencie = updatedRecipe.Ingrediencie;
            existingRecipe.VegetarianskeJedlo = updatedRecipe.VegetarianskeJedlo;

            // Save changes to the database
            kuchynkaDbContext.SaveChanges();
            return true;
        }
    }
}
