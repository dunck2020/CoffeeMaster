using Microsoft.AspNetCore.Mvc;

namespace CoffeeMaster.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
