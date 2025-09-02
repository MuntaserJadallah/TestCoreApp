using Microsoft.AspNetCore.Mvc;
using System.Collections;
using TestCoreApp.Data;
using TestCoreApp.Models;

namespace TestCoreApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> itemlist = _db.Items.ToList();
            return View(itemlist);
        }

        // GET NEW VIEW 
        public IActionResult New()
        {
            return View();
        }

        // POST
        [HttpPost]                  // using post
        [ValidateAntiForgeryToken]  // using validate 
        public IActionResult New(Item item)
        {
            /*
            if (item.Price <= 200) // Custom Error (2)
            {
                ModelState.AddModelError("Price", "السعر لا يجب أن يكون أقل من 200");
            }

            if (item.Name == "30") // Custom Error (2)  / Just For testing :)
            {
                ModelState.AddModelError("Name", "حقل الإســم يجب أن يكون على الأقل 30 حرف");
            }
            */

            if (ModelState.IsValid) // Validate Model (1)
            {
                _db.Items.Add(item); // Save In DbContext
                _db.SaveChanges();   // Commit to Database
                return RedirectToAction("Index", "Items"); 
            }
            else
            {
                return View("New");
            }
        }


        /// Edit start --------------------------------
        public IActionResult Edit(int? Id) //======== (1)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var item = _db.Items.FirstOrDefault(x => x.Id == Id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [HttpPost]                  
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(Item item)  //======== (2)
        {

            if (ModelState.IsValid) // Validate Model (1)
            {
                _db.Items.Update(item); // update In DbContext
                _db.SaveChanges();   // Commit to Database
                return RedirectToAction("Index", "Items");
            }
            else
            {
                return View("Edit");
            }
        }

        /// Edit End --------------------------------


        /// Delete start --------------------------------
        public IActionResult Delete(int? Id) //======== (1)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(Item item)  //======== (2)
        //{

        //    if (ModelState.IsValid) // Validate Model (1)
        //    {
        //        _db.Items.Remove(item); // remove from DbContext
        //        _db.SaveChanges();   // Commit to Database
        //        return RedirectToAction("Index", "Items");
        //    }
        //    else
        //    {
        //        return View("Delete");
        //    }
        //}

        // Method (2) - Delete by action name

        [HttpPost,ActionName("DeleteItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int ?Id)  //======== (2)
        {

        var item = _db.Items.Find(Id);

        if (item == null) 
        {
            return NotFound();
        }

        _db.Items.Remove(item); // remove from DbContext
        _db.SaveChanges();   // Commit to Database

        return RedirectToAction("Index", "Items");
         
        }

        /// Delete End --------------------------------
    }
}
