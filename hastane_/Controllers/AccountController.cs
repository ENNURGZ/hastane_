using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;

namespace hastane_.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IConfiguration _configuration;
        public AccountController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }

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
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    View(model);
                }
                else
                {
                    string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                    string saltedPassword = model.Password + md5Salt;
                    string hashedPassword = saltedPassword.MD5();
                    User user = new()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Username = model.Username,
                        Password = hashedPassword
                    };

                    _databaseContext.Users.Add(user);
                    int affectedRowCount = _databaseContext.SaveChanges();

                    if (affectedRowCount == 0)
                    {
                        ModelState.AddModelError("", "Kullanıcı Eklenemedi.");
                    }
                    else
                    {
                        return RedirectToAction(nameof(Login));
                    }
                }
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
