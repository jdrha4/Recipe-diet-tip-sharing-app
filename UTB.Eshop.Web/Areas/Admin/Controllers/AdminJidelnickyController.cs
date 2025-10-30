using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Identity.Enums;

namespace UTB.Eshop.Web.Areas.Customer.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class AdminJidelnickyController : Controller
    {

        private readonly IAdminJidelnicekManagement _adminJidelnicekService;

        public AdminJidelnickyController(IJidelnicekService jidelnicekService, IAdminJidelnicekManagement adminJidelnicekService)
        {
            _adminJidelnicekService = adminJidelnicekService ?? throw new ArgumentNullException(nameof(adminJidelnicekService));
        }


        public IActionResult Index()
        {
            IList<Jidelnicek> jidelnicky = _adminJidelnicekService.Select();
            return View(jidelnicky);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _adminJidelnicekService.Delete(id);

            if (deleted)
                return RedirectToAction(nameof(AdminJidelnickyController.Index));
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var jidelnicek = _adminJidelnicekService.GetJidelnicekById(id);

            if (jidelnicek == null)
            {
                return NotFound();
            }

            return View(jidelnicek);
        }

        [HttpPost]
        public IActionResult Edit(Jidelnicek jidelnicek)
        {

            bool updated = _adminJidelnicekService.UpdateJidelnicek(jidelnicek);

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
