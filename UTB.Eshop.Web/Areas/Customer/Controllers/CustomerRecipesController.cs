using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Application.Implementation;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity;
using UTB.Eshop.Infrastructure.Identity.Enums;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = nameof(Roles.Customer))]
    public class CustomerRecipesController : Controller
    {

        ISecurityService iSecure;
        IRecipeCustomerService recipeCustomerService;
        IRecipeCreationService recipeCreationService;

        public CustomerRecipesController(ISecurityService iSecure,
                                         IRecipeCustomerService recipeCustomerService,
                                         IRecipeCreationService recipeCreationService)
        {
            this.iSecure = iSecure;
            this.recipeCustomerService = recipeCustomerService;
            this.recipeCreationService = recipeCreationService;
        }


        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User currentUser = await iSecure.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<Recipe> userRecipes = recipeCustomerService.GetRecipesForUser(currentUser.Id);
                    return View(userRecipes);
                }
            }

            return NotFound();
        }

        [HttpGet] //vychozi atribut pro akcni metody
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Recipe recipe)
        {

            // Get the current user
            var currentUser = await iSecure.GetCurrentUser(User);

            // Check if the user is authenticated
            if (currentUser != null)
            {
                // Set the UserId for the recipe
                recipe.UserId = currentUser.Id;

                // Add the recipe
                recipeCreationService.AddRecipe(recipe);

                return RedirectToAction(nameof(Index));
            }

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = recipeCustomerService.Delete(id);

            if (deleted)
                return RedirectToAction(nameof(Manage));  // Redirects back to the Manage action after deletion.
            else
                return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User currentUser = await iSecure.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<Recipe> userRecipes = recipeCustomerService.GetRecipesForUser(currentUser.Id);
                    return View("Manage", userRecipes);
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the recipe with the specified ID
            var recipe = recipeCustomerService.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            // Validate the recipe or perform any additional validation logic

            // Update the recipe in the database
            bool updated = recipeCustomerService.UpdateRecipe(recipe);

            if (updated)
            {
                return RedirectToAction(nameof(Manage));
            }
            else
            {
                // Handle the case where the update fails (e.g., recipe not found)
                return NotFound();
            }
        }


    }
}
