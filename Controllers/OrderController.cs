using Microsoft.AspNetCore.Mvc;

namespace TyskaForSmaUpptackare.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
