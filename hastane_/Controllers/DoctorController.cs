using AutoMapper;
using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        [Authorize(Roles = "admin")]
        public IActionResult RandevuList()
        {
            List<RandevuListViewModel> randevular =
                _databaseContext.Randevular.ToList()
                .Select(x => _mapper.Map<RandevuListViewModel>(x)).ToList();
            return View(randevular);
        }
    }
}
