using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestOBS.Models;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Protocol;

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
               .Include(t => t.Lessons)
                .FirstOrDefault(t => t.Id == id && t.Password == t.Password);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        [HttpGet]
        public IActionResult TakeLesson(int Id)
        {
            var lessons = _context.Lessons.ToList();
            ViewBag.TeacherId = Id;
            return View(lessons);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeLesson(int Id, List<int> selectedLessons)
        {
            var teacher = _context.Teachers
            .Include(t => t.Lessons)
            .FirstOrDefault(t => t.Id == Id);

            if (teacher == null)
            {
                return NotFound("Öğretmen bulunamadı");
            }

            foreach (var lessonId in selectedLessons)
            {
                var lesson = _context.Lessons.Find(lessonId);
                if (lesson != null)
                {
                    lesson.TeacherId = Id;
                    _context.Lessons.Update(lesson);
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Dashboard", new { Id });
        }
        [HttpGet]

        public IActionResult Profile(int id)
        {

            var teacher = _context.Teachers
            .Include(t => t.Lessons)
                                  .FirstOrDefault(t => t.Id == id);


            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher); // View tek öğretmeni alıyor
        }



    }
}