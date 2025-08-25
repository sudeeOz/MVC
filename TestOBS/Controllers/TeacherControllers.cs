using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestOBS.Models;
using System.Linq;

namespace TestOBS.Controllers
{
    public class TeacherController : Controller
    {
        private readonly RepositoryContext _context;

        public TeacherController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(int id, string password)
        {
            var teacher = _context.Teachers.FirstOrDefault(a => a.Id == id && a.Password == password);
            if (teacher != null)
            {
                   return RedirectToAction("Dashboard", new { id = teacher.Id });
            }
            else
            {
                ViewBag.Error = "Invalid ID or password!";
                return View();
            }
        }
       [HttpGet] 
        public IActionResult Dashboard(int id)
        {
            var teacher = _context.Teachers
                .FirstOrDefault(t => t.Id == id && t.Password == t.Password);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }
        [HttpGet]
        public IActionResult TakeLesson()
        {
            return View("~/Views/Teacher/TakeLesson.cshtml");
        }

        [HttpPost]

        public IActionResult TakeLesson(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Lessons.Add(lesson);
                _context.SaveChanges();
                return RedirectToAction("Dashboard", new { id = lesson.Id });
            }
            else
            {
                return View(lesson);
            }
        }
        [HttpGet]

        public IActionResult Profile(int id)
        {

            var teacher = _context.Teachers
                                  .FirstOrDefault(t => t.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher); // View tek öğretmeni alıyor
        }



    }
}