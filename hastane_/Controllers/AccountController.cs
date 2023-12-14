using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    public class AccountController : Controller
    {
        //private readonly DatabaseContext _databaseContext;

        /*public AccountController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }*/

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
                /*Hasta hasta = new()
                {

                    Username = model.Username,
                    Password = model.Password,
                };
                k.Add(hasta);
                int affectedRowCount = k.SaveChanges();
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Hasta eklenemedi.");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }*/
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
