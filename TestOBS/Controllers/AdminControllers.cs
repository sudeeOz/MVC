using Microsoft.AspNetCore.Mvc;
using TestOBS.Models;
using System.Linq;

namespace TestOBS.Controllers
{
    public class AdminController : Controller
    {
        private readonly RepositoryContext _context;

        public AdminController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(int adminId, string password)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == adminId && a.Password == password);

            if (admin != null)
            {
                // Giriş başarılı, admin paneline yönlendir
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                // Hatalı giriş, hata mesajı göster
                ViewBag.Error = "Kullanıcı adı veya şifre hatalı!";
                return View();
            }
        }

        public IActionResult Dashboard()
        {
            // Admin paneli
            return View();
        }
    }
}