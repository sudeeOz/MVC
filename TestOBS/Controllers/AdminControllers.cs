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
            var admins = _context.Admins.ToList();
            return View(admins);
        }
        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View("~/Views/Admin/CreateTeacher.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return View("~/Views/Admin/CreateTeacher.cshtml", teacher);
            }
        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View("~/Views/Admin/CreateStudent.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return View("~/Views/Admin/CreateStudent.cshtml", student);
            }
        }
        [HttpGet]
        public IActionResult AddLesson()
        {
            return View("~/Views/Admin/AddLesson.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLesson(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return View("~/Views/Admin/AddLesson.cshtml", lesson);
            }
        }
    }
}