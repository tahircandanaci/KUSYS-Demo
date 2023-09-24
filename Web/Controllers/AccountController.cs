using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork uow) : base(uow)
        {
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            var user = await Uow.UserRepository.GetUserAsync(loginViewModel.Username, loginViewModel.Password);
            if (user != null)
            {
                Helper.SetUserSession(HttpContext, user);
                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "Giriş başarısız !";
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            Helper.ClearSession(HttpContext);
            return RedirectToAction("Index", "Home");
        }
    }
}
