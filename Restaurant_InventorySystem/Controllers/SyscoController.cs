using Microsoft.AspNetCore.Mvc;
using Restaurant_InventorySystem.Data;
using Restaurant_InventorySystem.Models;

namespace Restaurant_InventorySystem.Controllers
{
    public class SyscoController : Controller
    {
        private readonly InventorySystemContext _db;
        public SyscoController(InventorySystemContext db)
        {
            this._db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Sysco> obj = _db.Syscos;

            return View(obj);
        }
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
        public IActionResult Create(Sysco obj)
        {

            if (ModelState.IsValid)
            {
                _db.Syscos.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Sysco Item created successfully";
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

            var syscoFromDb = _db.Syscos.Find(id);
            if (syscoFromDb == null)
                return NotFound();

            return View(syscoFromDb);
        }
        /// <summary>
        /// Post Action Method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Sysco obj)
        {

            if (ModelState.IsValid)
            {
                _db.Syscos.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Sysco Item updated successfully";
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

            var syscoFromDb = _db.Syscos.Find(id);
            if (syscoFromDb == null)
                return NotFound();

            return View(syscoFromDb);
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
            var obj = _db.Syscos.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            _db.Syscos.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Sysco Item deleted successfully";
            return RedirectToAction("Index");


        }
    }
}
