using AutoMapper;
using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hastane_.Controllers
{
    public class UserController : Controller
    {

        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            List<UserModel> users = 
                _databaseContext.Users.ToList()
                .Select(x => _mapper.Map<UserModel>(x)).ToList();
            return View(users);
        }
    }
}
