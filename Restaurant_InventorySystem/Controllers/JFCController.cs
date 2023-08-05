using Microsoft.AspNetCore.Mvc;

namespace Restaurant_InventorySystem.Controllers
{
    public class JFCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
