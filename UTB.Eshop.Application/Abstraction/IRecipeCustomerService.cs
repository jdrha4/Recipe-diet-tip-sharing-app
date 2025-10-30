using System;
using System.Collections.Generic;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IRecipeCustomerService
    {
        IList<Recipe> GetRecipesForUser(int userId);

        bool Delete(int id);

        Recipe GetRecipeById(int id);  

        bool UpdateRecipe(Recipe updatedRecipe);
    }
}
