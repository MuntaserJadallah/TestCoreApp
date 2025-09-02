using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Data;
using TestCoreApp.Models;

namespace TestCoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categries.ToList();
            return View(categoryList);
        }
        // GET New
        public IActionResult New()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            /*
            if (category.Cat_Name == "30")
            {
                ModelState.AddModelError("Cat_Name", "إسم الفئـة يجب أن لا يقل من 30 حرف");
            }
            */

            if (ModelState.IsValid)
            {
                _db.Categries.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }

        }

        // Edit start ----------------
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0) 
            { 
                return NotFound(); 
            }
            var Category = _db.Categries.FirstOrDefault(c => c.Id == Id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categries.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View("Edit");
            }

        }
        // Edit End ----------------

        // Delete start ----------------
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var Category = _db.Categries.Find(Id);
            if (Category == null)
            {
                return NotFound();
            }

            return View(Category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categries.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View("Delete");
            }

        }

        // Delete End ----------------



    }
}
