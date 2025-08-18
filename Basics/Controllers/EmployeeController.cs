using Basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index1() //Action
        {
            string message = $"Hello World. {DateTime.Now.ToString()}";
            return View("Index1",message);
        }

        public ViewResult Index2()
        {
            var names = new String[]
            {
                "Ahmet",
                "Mehmet",
                "Ayşe"
            };
            return View("Index2",names);
        }
        public IActionResult Index3()
        {
            var list = new List<Employee>()
            {
                 new Employee { Id = 1, FirstName= "Ahmet", LastName = "Yılmaz", Age = 30 },
                 new Employee { Id = 2, FirstName= "Mehmet", LastName = "Öztürk", Age = 25 },
                 new Employee { Id = 3, FirstName= "Ayşe", LastName = "Demir", Age = 28 },
            };
            return View("Index3",list);
        }
    }
}