using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
