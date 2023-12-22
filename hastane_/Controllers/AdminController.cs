using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
