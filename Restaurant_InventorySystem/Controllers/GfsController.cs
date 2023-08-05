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
    }
}
