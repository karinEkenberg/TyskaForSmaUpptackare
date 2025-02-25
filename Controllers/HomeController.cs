using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TyskaForSmaUpptackare.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace TyskaForSmaUpptackare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 10,
            Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            return View();
        }

        [Route("private")]
        [Authorize(Roles = "Administrators, Customer")]
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
