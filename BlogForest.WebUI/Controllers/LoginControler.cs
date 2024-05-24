using BlogForest.DtoLayer.LoginDtos;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Controllers
{
    public class LoginControler : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginControler ( SignInManager<AppUser> signInManager )
        {
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index ()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto )
        {
            var result = await _signInManager.PasswordSignInAsync(createLoginDto.UserName, createLoginDto.Password,  false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();

        }
    }
}
