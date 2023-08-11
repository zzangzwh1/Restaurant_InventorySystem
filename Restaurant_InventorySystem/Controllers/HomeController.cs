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
/*        [HttpPost]
        public List<object> GetData()
        {
        
            List<object> dataResult = new List<object>();

            List<string> gfsProdcuts = _db.Gfs.Select(i => i.ProductName).ToList();
            
            List<string> etcProdcuts = _db.Etcs.Select(i => i.ProductName).ToList();
            List<string> jkcProdcuts = _db.Jfcs.Select(i => i.ProductName).ToList();
            List<string> syscoProduct = _db.Syscos.Select(i => i.ProductName).ToList();

            dataResult.Add(gfsProdcuts);
            dataResult.Add(etcProdcuts);
            dataResult.Add(jkcProdcuts);
            dataResult.Add(syscoProduct);

            List<double> gfsPrice = _db.Gfs.Select(i => (double)i.Price).ToList();

        }
*/
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