using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    [Authorize(Roles = "user")]
    public class HastaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
