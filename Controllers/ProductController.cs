using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TyskaForSmaUpptackare.Data;
using TyskaForSmaUpptackare.Models;

namespace TyskaForSmaUpptackare.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController (ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: ProductController/Create
        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Edit/5
        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
           if (id != product.ProductId)
            {
                return NotFound();
            }
           if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           return View(product);
        }

        // GET: ProductController/Delete/5
        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: ProductController/Delete/5
        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrators, Customers")]
        public async Task<IActionResult> Explore(int id)
        {
            var product = await _context.Products
                .Include(p => p.Parts)  
                .ThenInclude(part => part.Items)  
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
