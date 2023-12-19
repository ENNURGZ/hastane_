using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorController : Controller
    {
        public IActionResult RandevuListele()
        {
            return View();
        }
        public IActionResult RandevuDuzenle()
        {
            return View();
        }
    }
}
