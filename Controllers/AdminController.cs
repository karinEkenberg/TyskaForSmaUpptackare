using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Orders()
        {
            var orders = _context.Orders
                .Include(o => o.User) // Ladda relaterad användardata
                .Include(o => o.OrderItems) // Ladda relaterade orderartiklar
                .ThenInclude(oi => oi.Product) // Ladda relaterad produktdata
                .OrderByDescending(o => o.CreatedAt) // Sortera efter senaste order
                .ToList();

            return View("orders", orders); // Skicka datan till vyn
        }
    }
}
