using hastane_.Entities;
using hastane_.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hastane_.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AccountController(DatabaseContext databaseContext, IConfiguration configuration, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)  //Login işlemleri
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = DoMD5HashedString(model.Password);

                User user = _databaseContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                && x.Password == hashedPassword);
                Admin admin = _databaseContext.Adminler.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                && x.Password == hashedPassword);
                Doctor doctor = _databaseContext.Doctors.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                && x.Password == hashedPassword);

                if (user != null && admin==null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(model.Username), "User is locked.");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.Name ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Name, user.Surname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("Username", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                if (user == null && admin != null)
                {
                    if (admin.Locked)
                    {
                        ModelState.AddModelError(nameof(model.Username), "Admin is locked.");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, admin.Name ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Name, admin.Surname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, admin.Role));
                    claims.Add(new Claim("Username", admin.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Admin");
                }
                if (doctor != null && admin == null)
                {
                    if (doctor.Locked)
                    {
                        ModelState.AddModelError(nameof(model.Username), "Doctor is locked.");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, doctor.DoctorId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, doctor.Name ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Name, doctor.Surname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, doctor.Role));
                    claims.Add(new Claim("Username", doctor.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                }
            }

            return View(model);

        }

        private string DoMD5HashedString(string s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
            string salted = s + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
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
                    string hashedPassword = DoMD5HashedString(model.Password);

                    User user = new()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Username = model.Username,
                        Password = hashedPassword,
                        Role = "user"
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
        
        [Authorize(Roles = "admin")]
        public IActionResult AdminKaydi()
        {
            return View();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AdminKaydi(AdminListViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Adminler.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    View(model);
                }
                else
                {
                    string hashedPassword = DoMD5HashedString(model.Password);

                    Admin admin = new()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Username = model.Username,
                        Password = hashedPassword,
                        Role = "admin"
                    };

                    _databaseContext.Adminler.Add(admin);
                    int affectedRowCount = _databaseContext.SaveChanges();

                    if (affectedRowCount == 0)
                    {
                        ModelState.AddModelError("", "Kullanıcı Eklenemedi.");
                    }
                    else
                    {
                        return RedirectToAction("AdminList", "User");
                    }
                }
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public IActionResult DoctorKaydi()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DoctorKaydi(DoctorListViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Doctors.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    View(model);
                }
                else
                {
                    string hashedPassword = DoMD5HashedString(model.Password);

                    Doctor doctor = new()
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Username = model.Username,
                        Password = hashedPassword,
                        PoliklinikId = model.PoliklinikId,
                        CalismaGunu = model.CalismaGunu,
                        BaslangicSaati = model.BaslangicSaati,
                        BitisSaati = model.BitisSaati,
                        Role = "doctor"
                    };

                    _databaseContext.Doctors.Add(doctor);
                    int affectedRowCount = _databaseContext.SaveChanges();

                    if (affectedRowCount == 0)
                    {
                        ModelState.AddModelError("", "Kullanıcı Eklenemedi.");
                    }
                    else
                    {
                        return RedirectToAction("DoctorList", "User");
                    }
                }
            }
            return View(model);
        }
        
        
        [Authorize(Roles = "admin")]
        public IActionResult DoctorDuzenle(Guid id)
        {
            Doctor doctor = _databaseContext.Doctors.Find(id);
            DoctorDuzenleViewModel model = _mapper.Map<DoctorDuzenleViewModel>(doctor);
            
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult DoctorDuzenle(Guid id, DoctorDuzenleViewModel model)
        {
            if(ModelState.IsValid) 
            {
                Doctor doctor = _databaseContext.Doctors.Find(id);

                _mapper.Map(model, doctor);
                _databaseContext.SaveChanges();

                return RedirectToAction("DoctorList", "User");
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            ProfileInfoLoader();

            return View();
        }

        private void ProfileInfoLoader()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

            ViewData["Username"] = user.Username;
        }

        [HttpPost]
        public IActionResult ProfileChangeUsername([Required][StringLength(30)] string username)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

                user.Username = username;
                _databaseContext.SaveChanges();

                ViewData["result"] = "UsernameChanged";
                //return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();
            return View("Profile");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(Guid id)
        {
            User user = _databaseContext.Users.Find(id);

            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();

            return RedirectToAction("Index", "User");
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteDoctor(Guid id)
        {
            Doctor doctor = _databaseContext.Doctors.Find(id);

            _databaseContext.Doctors.Remove(doctor);
            _databaseContext.SaveChanges();

            return RedirectToAction("DoctorList", "User");
        }

        [Authorize(Roles = "admin")]
        public IActionResult DeleteAdmin(Guid id)
        {
            Admin admin = _databaseContext.Adminler.Find(id);

            _databaseContext.Adminler.Remove(admin);
            _databaseContext.SaveChanges();

            return RedirectToAction("AdminList", "User");
        }
        [Authorize(Roles = "admin")]
        public IActionResult DeleteRandevu(Guid id)
        {
            Randevu randevu = _databaseContext.Randevular.Find(id);

            _databaseContext.Randevular.Remove(randevu);
            _databaseContext.SaveChanges();

            return RedirectToAction("RandevuList", "Doctor");
        }

        [HttpPost]
        public IActionResult ProfileChangePassword([Required][MinLength(6)][MaxLength(16)] string password)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

                string hashedPassword = DoMD5HashedString(password);

                user.Password = hashedPassword;
                _databaseContext.SaveChanges();

                ViewData["result"] = "PasswordChanged";
            }
            ProfileInfoLoader();
            return View("Profile");
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        // AccountController.cs
        // ...


        // ...
        [AllowAnonymous]
        public IActionResult RandevuAl()
        {
            // ViewBag.DoctorList = new SelectList(_databaseContext.Doctors, "DoctorId", "Name");
            ViewBag.DoctorList = new SelectList(_databaseContext.Doctors, "DoctorId", "FullName");
            //ViewBag.UserList = new SelectList(_databaseContext.Users, "Id", "Username");
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
            public IActionResult RandevuAl(RandevuAlViewModel model)
            {
                if (ModelState.IsValid)
                {
                    // Kullanıcının daha önce aynı tarih ve saatte randevu alıp almadığını kontrol et
                    if (IsAppointmentTimeTaken(model.DoctorId, model.RandevuGunu, model.RandevuSaati))
                    {
                        ModelState.AddModelError("", "Seçtiğiniz tarih ve saatte başka bir randevu bulunmaktadır. Lütfen başka bir tarih veya saat seçin.");
                  //  ViewBag.DoctorList = new SelectList(_databaseContext.Doctors, "DoctorId", "Name");
                    ViewBag.DoctorList = new SelectList(_databaseContext.Doctors, "DoctorId", "FullName");
                    //ViewBag.UserList = new SelectList(_databaseContext.Users, "Id", "Username");
                    return View(model);
                    }
                Guid userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                model.UserId = userId;

                // Randevu alma işlemleri...
                var randevu = new Randevu
                    {
                        RandevuId = Guid.NewGuid(),
                        Id = model.UserId,
                        DoctorId = model.DoctorId,
                        RandevuGunu = model.RandevuGunu,
                        RandevuSaati = model.RandevuSaati
                    };

                    _databaseContext.Randevular.Add(randevu);
                    _databaseContext.SaveChanges();
               
                return RedirectToAction("RandevuListesi", "User");
                       
                }
            //ViewBag.DoctorList = new SelectList(_databaseContext.Doctors, "DoctorId", "Name");
            ViewBag.DoctorList = new SelectList(_databaseContext.Doctors, "DoctorId", "FullName");
            // ViewBag.UserList = new SelectList(_databaseContext.Users, "Id", "Username");
            return View(model);
            }

            // ...

            private bool IsAppointmentTimeTaken(Guid doctorId, DateTime randevuGunu, TimeSpan randevuSaati)
            {
                // Seçilen tarih ve saatte başka bir randevu var mı kontrol et
                return _databaseContext.Randevular.Any(r =>
                    r.DoctorId == doctorId &&
                    r.RandevuGunu == randevuGunu.Date && // Tarih kıyaslaması sadece gün, ay, yıl olarak yapılır
                    r.RandevuSaati == randevuSaati);
            }


    }



}
