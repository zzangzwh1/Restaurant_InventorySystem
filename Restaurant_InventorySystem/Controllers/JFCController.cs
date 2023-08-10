using Microsoft.AspNetCore.Mvc;
using Restaurant_InventorySystem.Data;
using Restaurant_InventorySystem.Models;

namespace Restaurant_InventorySystem.Controllers
{
    public class JFCController : Controller
    {
        private readonly InventorySystemContext _db;

        public JFCController(InventorySystemContext db)
        {
            this._db = db;                
        }
        public IActionResult Index()
        {
            IEnumerable<Jfc> obj = _db.Jfcs;
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
        public IActionResult Create(Jfc obj)
        {

            if (ModelState.IsValid)
            {
                _db.Jfcs.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "JFC Item created successfully";
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

            var jfcFromDb = _db.Jfcs.Find(id);
            if (jfcFromDb == null)
                return NotFound();

            return View(jfcFromDb);
        }
        /// <summary>
        /// Post Action Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Jfc obj)
        {

            if (ModelState.IsValid)
            {
                _db.Jfcs.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "JFC Item updated successfully";
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

            var jfcFromDb = _db.Gfs.Find(id);
            if (jfcFromDb == null)
                return NotFound();

            return View(jfcFromDb);
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
            var obj = _db.Jfcs.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            _db.Jfcs.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "JFC Item deleted successfully";
            return RedirectToAction("Index");


        }
    }
}
