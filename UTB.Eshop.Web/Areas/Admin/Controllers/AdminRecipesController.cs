using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity.Enums;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class AdminRecipesController : Controller
    {

        private readonly IAdminRecipeManagement _adminRecipeService;

        public AdminRecipesController(IRecipeService recipeService, IAdminRecipeManagement adminRecipeService)
        {
            _adminRecipeService = adminRecipeService ?? throw new ArgumentNullException(nameof(adminRecipeService));
        }


        public IActionResult Index()
        {
            IList<Recipe> recipes = _adminRecipeService.Select();
            return View(recipes);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _adminRecipeService.Delete(id);

            if (deleted)
                return RedirectToAction(nameof(AdminRecipesController.Index));
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recipe = _adminRecipeService.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {

            bool updated = _adminRecipeService.UpdateRecipe(recipe);

            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
