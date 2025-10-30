using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Eshop.Application.ViewModels;
using UTB.Eshop.Domain.Entities;

namespace UTB.Eshop.Application.Abstraction
{
    public interface IAdminRecipeManagement

    {
        IList<Recipe> Select();
       
        bool Delete(int id);

        Recipe GetRecipeById(int id);

        bool UpdateRecipe(Recipe updatedRecipe);

    }
}
