using Microsoft.AspNetCore.Mvc;

namespace Restaurant_InventorySystem.Controllers
{
    public class SyscoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
