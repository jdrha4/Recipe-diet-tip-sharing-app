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
    public class CustomerJidelnickyController : Controller
    {

        ISecurityService iSecure;
        IJidelnicekCustomerService jidelnicekCustomerService;
        IJidelnicekCreationService jidelnicekCreationService;

        public CustomerJidelnickyController(ISecurityService iSecure,
                                         IJidelnicekCustomerService jidelnicekCustomerService,
                                         IJidelnicekCreationService jidelnicekCreationService)
        {
            this.iSecure = iSecure;
            this.jidelnicekCustomerService = jidelnicekCustomerService;
            this.jidelnicekCreationService = jidelnicekCreationService;
        }


        public async Task<IActionResult> Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                User currentUser = await iSecure.GetCurrentUser(User);
                if (currentUser != null)
                {
                    IList<Jidelnicek> userJidelnicky = jidelnicekCustomerService.GetJidelnickyForUser(currentUser.Id);
                    return View(userJidelnicky);
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
        public async Task<IActionResult> Create(Jidelnicek jidelnicek)
        {

            // Get the current user
            var currentUser = await iSecure.GetCurrentUser(User);

            // Check if the user is authenticated
            if (currentUser != null)
            {
                // Set the UserId for the recipe
                jidelnicek.UserId = currentUser.Id;

                // Add the recipe
                jidelnicekCreationService.AddJidelnicek(jidelnicek);

                return RedirectToAction(nameof(Index));
            }

            return View(jidelnicek);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bool deleted = jidelnicekCustomerService.Delete(id);

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
                    IList<Jidelnicek> userJidelnicky = jidelnicekCustomerService.GetJidelnickyForUser(currentUser.Id);
                    return View("Manage", userJidelnicky);
                }
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Retrieve the recipe with the specified ID
            var jidelnicek = jidelnicekCustomerService.GetJidelnicekById(id);

            if (jidelnicek == null)
            {
                return NotFound();
            }

            return View(jidelnicek);
        }

        [HttpPost]
        public IActionResult Edit(Jidelnicek jidelnicek)
        {
            // Validate the recipe or perform any additional validation logic

            // Update the recipe in the database
            bool updated = jidelnicekCustomerService.UpdateJidelnicek(jidelnicek);

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
