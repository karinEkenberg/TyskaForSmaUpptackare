using Microsoft.AspNetCore.Mvc;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Controllers
{
    public class TestaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Abc()
        {
            var abcs = _context.Abcs.ToList();
            return View(abcs);
        }

        public IActionResult Djur()
        {
            var animals = _context.Animals.ToList();
            return View(animals);
        }

        public IActionResult EttTvaTre()
        {
            var numbers = _context.NumberOneTwos.ToList();
            return View(numbers);
        }

        public IActionResult Tiotal()

        {
            var numbers = _context.NumbersTens.ToList();
            return View(numbers);
        }

        public IActionResult Hundratal()
        {
            var numbers = _context.NumbersHundred.ToList();
            return View(numbers);
        }
    }
}
