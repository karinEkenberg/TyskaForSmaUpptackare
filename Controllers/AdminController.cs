using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe.Climate;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await _context.Orders.ToListAsync();
            Console.WriteLine($"Antal ordrar: {orders.Count}");
            return View(orders);
        }

    }
}