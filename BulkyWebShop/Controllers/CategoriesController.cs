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
        public IActionResult Index()
        {
            List<Category> CategoryList = _context.Categories.ToList<Category>(); 
            return View(CategoryList);
        }

        public IActionResult CreateCategory() { 
            
            return View();
        }
    }
}
