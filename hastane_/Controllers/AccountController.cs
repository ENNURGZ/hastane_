using hastane_.Models;
using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //login işlemleri
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //REGİSTER İŞLEMLERİ
            }
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
