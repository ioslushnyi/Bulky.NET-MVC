using BulkyWebShop.Data;
using BulkyWebShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()//test
        {
            List<Category> CategoryList = _context.Categories.ToList<Category>(); 
            return View(CategoryList);
        }

        public IActionResult CreateCategory() { 
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name must be different from DisplayOrder");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index", "Categories");
            }
            return View();
        }
    }
}
