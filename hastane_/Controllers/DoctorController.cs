using AutoMapper;
using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace hastane_.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public DoctorController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        [Authorize(Roles = "doctor")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "doctor")]
        public IActionResult DoctorRandevuListesi()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Kullanıcının randevularını getir
            var randevular = _databaseContext.Randevular
                .Include(r => r.User)
                .Where(r => r.DoctorId == userId)
                .ToList();

            return View(randevular);
        }
    }
}
