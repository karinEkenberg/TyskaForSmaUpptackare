using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TyskaForSmaUpptackare.ViewModel;
using TyskaForSmaUpptackare.Data;
using TyskaForSmaUpptackare.Services;

namespace TyskaForSmaUpptackare.Controllers
{
    public class HemController : Controller
    {
        private readonly ILogger<HemController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public HemController(ILogger<HemController> logger, ApplicationDbContext context, EmailService emaiService)
        {
            _logger = logger;
            _context = context;
            _emailService = emaiService;
        }

        [ResponseCache(Duration = 10,
        Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Products = _context.Products.Take(3).ToList(),
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendContact(HomeViewModel model)
        {
            ModelState.Remove("Products");

            if (!ModelState.IsValid)
            {
                model.Products = _context.Products.Take(3).ToList();
                return View("Index", model);
            }

            var subject = "Nytt meddelande från hemsidan";
            var content = $"<p><strong>Från:</strong> {model.Contact.Name} ({model.Contact.Email})</p><p>{model.Contact.Message}</p>";

            try
            {
                await _emailService.SendEmailAsync("k.ekenberg.dev@gmail.com", subject, content);
                TempData["MessageSent"] = "true";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fel vid försök att skicka mejl.");
                ModelState.AddModelError("", "Mejlet kunde inte skickas. Försök igen senare.");
                model.Products = _context.Products.Take(3).ToList();
                return View("Index", model);
            }

            var newModel = new HomeViewModel
            {
                Products = _context.Products.Take(3).ToList(),
                Contact = new ContactViewModel { MessageSent = true }
            };

            return RedirectToAction("Index", new { section = "kontakt-formular" });
        }



    }
}
