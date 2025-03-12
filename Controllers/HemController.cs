using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TyskaForSmaUpptackare.ViewModel;
using Microsoft.AspNetCore.Authorization;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Controllers
{
    public class HemController : Controller
    {
        private readonly ILogger<HemController> _logger;
        private readonly ApplicationDbContext _context;

        public HemController(ILogger<HemController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [ResponseCache(Duration = 10,
        Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Products = _context.Products.ToList(),
            };
            return View(model);
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
