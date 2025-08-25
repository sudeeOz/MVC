using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using TestOBS.Models;

namespace TestOBS.Controllers
{
    public class AccountController : Controller
    {
        private readonly RepositoryContext _context;

        public AccountController(RepositoryContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }
        public IActionResult AdminLogin()
        {
            return View("~/Views/Admin/Login.cshtml");
        }
        public IActionResult TeacherLogin()
        {
            return View("~/Views/Teacher/Login.cshtml");
        }
        public IActionResult StudentLogin()
        {
            return View("~/Views/Student/Login.cshtml");
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View("~/Views/Account/Signup.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup([FromForm] Admin model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("Validation Hataları: " + string.Join(" | ", errors));
            }

            if (_context.Admins.Any(c => c.Email == model.Email))
            {
                ModelState.AddModelError("", "Bu E-mail adresine ait zaten hesap var.");
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    _context.Admins.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Login", "Account");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "Veritabanı hatası: " + ex.Message);
                    return View(model);
                }

            }
            return View(model);
        }

        private void ShowMessage(string v)
        {
            TempData["ErrorMessage"] = v;
        }
    }
}

