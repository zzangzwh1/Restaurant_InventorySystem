using Microsoft.AspNetCore.Mvc;
using Restaurant_InventorySystem.Data;
using Restaurant_InventorySystem.Models;

namespace Restaurant_InventorySystem.Controllers
{
    public class ETCController : Controller
    {
        private readonly InventorySystemContext _db;

        public ETCController(InventorySystemContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Etc> etcObj = _db.Etcs;
            return View(etcObj);
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
        public IActionResult Create(Etc obj)
        {

            if (ModelState.IsValid)
            {
                _db.Etcs.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "ETC Item created successfully";
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

            var etcFromDb = _db.Etcs.Find(id);
            if (etcFromDb == null)
                return NotFound();

            return View(etcFromDb);
        }
        /// <summary>
        /// Post Action Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Etc obj)
        {

            if (ModelState.IsValid)
            {
                _db.Etcs.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "ETC Item updated successfully";
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

            var etcFromDb = _db.Etcs.Find(id);
            if (etcFromDb == null)
                return NotFound();

            return View(etcFromDb);
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
            var obj = _db.Etcs.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            _db.Etcs.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "ETC Item deleted successfully";
            return RedirectToAction("Index");


        }

    }
}
