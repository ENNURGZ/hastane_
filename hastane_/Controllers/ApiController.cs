using AutoMapper;
using hastane_.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hastane_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public ApiController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Guid id)
        {
            var user = _databaseContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();

            return RedirectToAction("Index", "User");
        }
        


    }
}
