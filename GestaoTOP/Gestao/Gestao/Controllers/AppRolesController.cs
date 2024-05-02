
//using Gestao.Models; // Assuming this is where your role model resides
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;

//namespace Gestao.Controllers
//{
//    //[Authorize(Roles = "Admin")]
//    public class AppRolesController : Controller
//    {
//        private readonly RoleManager<IdentityRole> _roleManager;

//        public AppRolesController(RoleManager<IdentityRole> roleManager)
//        {
//            _roleManager = roleManager;
//        }

//        // List All the ROLES created by Users
//        public IActionResult Index()
//        {
//            var roles = _roleManager.Roles;
//            return View(roles);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(IdentityRole role) // Use IdentityRole
//        {
//            if (!await _roleManager.RoleExistsAsync(role.Name))
//            {
//                await _roleManager.CreateAsync(role);
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        // GET EDIT
//        [HttpGet]
//        public async Task<IActionResult> Edit(string id) // Use string for Id
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var role = await _roleManager.FindByIdAsync(id); // Use FindByIdAsync

//            if (role == null)
//            {
//                return NotFound();
//            }

//            // Remove or adjust SelectList if needed for editing roles
//            return View(role);
//        }

//        // POST EDIT
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(string id, IdentityRole role)
//        {
//            if (ModelState.IsValid)
//            {
//                var existingRole = await _roleManager.FindByIdAsync(id);
//                if (existingRole == null)
//                {
//                    return NotFound();
//                }

//                existingRole.Name = role.Name;  // Update role name

//                try
//                {
//                    await _roleManager.UpdateAsync(existingRole);
//                    return RedirectToAction(nameof(Index));
//                }
//                catch (DbUpdateException ex)
//                {
//                    // Handle potential exceptions during update (e.g., logging)
//                    ModelState.AddModelError("", "Failed to update role!");
//                }
//            }
//            return View(role); // Re-render view with validation errors (if any)
//        }


//        private async Task<bool> RoleExists(string id)
//        {
//            return await _roleManager.RoleExistsAsync(id);
//        }
//    }
//}


using Gestao.Models; // Assuming this is where your role model resides
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gestao.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // List All the ROLES created by Users
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role) // Use IdentityRole
        {
            if (!await _roleManager.RoleExistsAsync(role.Name))
            {
                await _roleManager.CreateAsync(role);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(string id) // Use string for Id
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id); // Use FindByIdAsync

            if (role == null)
            {
                return NotFound();
            }

            // Remove or adjust SelectList if needed for editing roles
            return View(role);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                var existingRole = await _roleManager.FindByIdAsync(id);
                if (existingRole == null)
                {
                    return NotFound();
                }

                existingRole.Name = role.Name;  // Update role name

                try
                {
                    await _roleManager.UpdateAsync(existingRole);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    // Handle potential exceptions during update (e.g., logging)
                    ModelState.AddModelError("", "Failed to update role!");
                }
            }
            return View(role); // Re-render view with validation errors (if any)
        }

        // GET DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            try
            {
                await _roleManager.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                // Handle potential exceptions during delete (e.g., logging)
                ModelState.AddModelError("", "Failed to delete role!");
                return View(role);
            }
        }

        private async Task<bool> RoleExists(string id)
        {
            return await _roleManager.RoleExistsAsync(id);
        }
    }
}

