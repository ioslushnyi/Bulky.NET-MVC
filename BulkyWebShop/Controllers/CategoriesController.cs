using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebShop.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoriesController(ICategoryRepository categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }
        public IActionResult Index()//test
        {
            List<Category> CategoryList = _categoryRepo.GetAll().ToList(); 
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
                ModelState.AddModelError("name", "name must be different from displayorder");
            }
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index", "Categories");
            }
            return View();
        }

        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(category);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Categories");
            }
            return View();
        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _categoryRepo.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Remove(category);
                _categoryRepo.Save();
                TempData["success"] = "Category deleted successfully";
                return RedirectToAction("Index", "Categories");
            }
            return View();
        }
    }
}
