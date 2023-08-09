using Microsoft.AspNetCore.Mvc;
using Restaurant_InventorySystem.Data;
using Restaurant_InventorySystem.Models;
using System.Diagnostics;

namespace Restaurant_InventorySystem.Controllers
{
    public class GfsController : Controller
    {
        private readonly InventorySystemContext _db;

        public GfsController(InventorySystemContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Gf> obj = _db.Gfs;
            return View(obj);
        }
        /// <summary>
        /// Get action method
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Post Action Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gf obj)
        {

            if (ModelState.IsValid)
            {
                _db.Gfs.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "GFS Item created successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var gfsFromDb = _db.Gfs.Find(id);
            if (gfsFromDb == null)
                return NotFound();

            return View(gfsFromDb);
        }
        /// <summary>
        /// Post Action Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Gf obj)
        {

            if (ModelState.IsValid)
            {
                _db.Gfs.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "GFS Item updated successfully";
                return RedirectToAction("Index");

            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var gfsFromDb = _db.Gfs.Find(id);
            if (gfsFromDb == null)
                return NotFound();

            return View(gfsFromDb);
        }
        /// <summary>
        /// Post Action Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Gfs.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            _db.Gfs.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "GFS Item deleted successfully";
            return RedirectToAction("Index");


        }

    }
}
