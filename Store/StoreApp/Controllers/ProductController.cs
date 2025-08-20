using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;

        public ProductController(RepositoryContext context) //önemli
        {
            _context = context;
        }

        /*public IEnumerable<Product> Index()
        {
            var context = new RepositoryContext(
                 new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite("DataSource = ProductDb.db")
                .Options);

            return _context.Products;
        }*/
        
        public IActionResult Index()
        {
            var model = _context.Products.ToList();
            return View(model);
        }
    }
}