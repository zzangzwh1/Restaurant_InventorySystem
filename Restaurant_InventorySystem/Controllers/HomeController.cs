using Microsoft.AspNetCore.Mvc;
using Restaurant_InventorySystem.Data;
using Restaurant_InventorySystem.Models;
using System.Diagnostics;

namespace Restaurant_InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly InventorySystemContext _db;


        public HomeController(ILogger<HomeController> logger,InventorySystemContext db)
        {
            _logger = logger;
            this._db = db;
        }
        /// <summary>
        /// Display Every item in inventory
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Gf> _Gfs = _db.Gfs.ToList();
            List<Etc> _Etc = _db.Etcs.ToList();
            List<Jfc> _Jfc = _db.Jfcs.ToList();
            List<Sysco> _Sysco = _db.Syscos.ToList();

            var viewItems = new ProductCategoriesModel
            {
                gfs = _Gfs,
                etc = _Etc,
                jfc = _Jfc,
                sysco = _Sysco

            
            };


            return View(viewItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}