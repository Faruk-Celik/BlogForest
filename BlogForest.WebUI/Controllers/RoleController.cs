using BlogForest.EntityLayer.Concrete;
using BlogForest.WebUI.Areas.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController ( UserManager<AppUser> userManager, RoleManager<AppRole> roleManager )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult RoleList ()
        {
            var value = _roleManager.Roles.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateRole ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole ( CreateRoleViewModel createRoleViewModel )
        {
            AppRole appRole = new AppRole
            {
                Name = createRoleViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("RoleList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole ( int id )
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            return RedirectToAction("RoleList");

        }
        [HttpGet]
        public async Task<IActionResult> UpdateRole ( int id )
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole ( UpdateViewModel updateViewModel )
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateViewModel.Id);
            value.Name = updateViewModel.Name;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction("RoleList");
        }


    }
}

