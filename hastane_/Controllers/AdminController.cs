using AutoMapper;
using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace hastane_.Controllers
{
    public class AdminController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public AdminController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        [Authorize(Roles = "admin")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public IActionResult AdminRandevuListesi()
        {
            var randevular = _databaseContext.Randevular
                .Include(r => r.Doctor)
                .Include(r => r.User)
                .ToList();

            return View(randevular);
        }
        

    }
}
