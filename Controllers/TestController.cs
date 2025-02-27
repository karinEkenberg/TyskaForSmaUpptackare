using Microsoft.AspNetCore.Mvc;

namespace TyskaForSmaUpptackare.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
