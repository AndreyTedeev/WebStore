using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Entities.Identity;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken, ActionName("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName };
                var registrationResult = await _userManager.CreateAsync(user, model.Password);

                if (registrationResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Role.User);
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var error in registrationResult.Errors)
                        ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl });

        [HttpPost, ValidateAntiForgeryToken, ActionName("Login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName,
                    model.Password,
                    model.RememberMe,
#if DEBUG
                    false
#else
                    true
#endif
                    );
                if (result.Succeeded)
                    return LocalRedirect(model.ReturnUrl ?? "/");
                else
                    ModelState.AddModelError("", "Wrong user name or password");
            }
            return View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
