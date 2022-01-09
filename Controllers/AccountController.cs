using _072_HammadArshad_Task1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _072_HammadArshad_Task1.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _usermanager;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _usermanager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login userlogin)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userlogin.username, userlogin.password, userlogin.remember, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(userlogin);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(Register register)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await CreateUserAsync(register);
                if (!result.Succeeded)
                {
                    foreach (var errorsMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorsMessage.Description);
                    }
                    return View(register);
                }
                return RedirectToAction("Login", "Account");
            }
            return View(register);
            
        }

        public async Task<IdentityResult> CreateUserAsync(Register registeruser)
        {
            IdentityUser user = new IdentityUser()
            {
                Email = registeruser.Email,
                UserName = registeruser.Username
            };
            IdentityResult result = await _usermanager.CreateAsync(user, registeruser.password);
            return (result);

        }
    }
}
