using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestOBS.Models;
using System.Linq;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace TestOBS.Controllers
{
    public class StudentController : Controller
    {
        private readonly RepositoryContext _context;

        public StudentController(RepositoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
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
            var student = _context.Students.FirstOrDefault(a => a.Id == id && a.Password == password);
            if (student != null)
            {
                return RedirectToAction("Dashboard", new { id = student.Id });
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
            var student = _context.Students
               .Include(s => s.Lessons)
                .FirstOrDefault(s => s.Id == id && s.Password == s.Password);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult TakeLesson(int Id)
        {
            var student = _context.Students
                   .FirstOrDefault(s => s.Id == Id);

            if (student == null)
            {
                return NotFound("Öğrenci bulunamadı");
            }

            // Öğrencinin bölümüne ait dersleri getir
            var lessons = _context.Lessons
                .Where(l => l.Department == student.Department) // Bölüme göre filtrele
                .ToList();

            // ViewBag ile öğrenci bilgilerini gönder
            ViewBag.StudentId = student.Id;
            ViewBag.StudentName = student.FullName;
            ViewBag.StudentDepartment = student.Department;
            ViewBag.StudentGrade = student.Grade;

            return View(lessons);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TakeLesson(int Id, List<int> selectedLessons)
        {
            var student = _context.Students
                    .Include(s => s.Lessons)
                    .FirstOrDefault(s => s.Id == Id);

                if (student == null)
                {
                    return NotFound("Öğrenci bulunamadı");
                }

                // Seçilen dersleri öğrenciye ekle
                foreach (var lessonId in selectedLessons)
                {
                    var lesson = _context.Lessons.Find(lessonId);
                    if (lesson != null)
                    {
                        // Öğrenci zaten bu derse kayıtlı mı kontrol et
                        if (!student.Lessons.Any(l => l.Id == lessonId))
                        {
                            student.Lessons.Add(lesson);
                        }
                    }
                }

                _context.SaveChanges();
                
                TempData["Success"] = $"{selectedLessons.Count} ders için başarıyla kayıt olundu!";
                return RedirectToAction("Dashboard", new { id = Id });
        }
        [HttpGet]

        public IActionResult Profile(int id)
        {

            var student = _context.Students
            .Include(s => s.Lessons)
            .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student); // View tek öğrenciyi alıyor
        }



    }
}