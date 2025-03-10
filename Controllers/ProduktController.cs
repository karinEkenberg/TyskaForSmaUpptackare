using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TyskaForSmaUpptackare.Data;
using TyskaForSmaUpptackare.Models;

namespace TyskaForSmaUpptackare.Controllers
{
    public class ProduktController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProduktController (ApplicationDbContext context)
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
            if (!ModelState.IsValid)
            {
                if(product.Items != null)
                {
                    foreach (var room in product.Items)
                    {
                        room.ParentItem = null;
                        if (room.ChildItems !=  null)
                        {
                            foreach (var item in room.ChildItems)
                            {
                                item.ParentItem = room;
                            }
                        }
                    }
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Produkten har skapats";
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [Authorize(Roles = "Administrators")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products
                .Include(p => p.Items)
                .ThenInclude(item => item.Parts)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product editedProduct)
        {
            Console.WriteLine("editedProduct.Items.Count = " + (editedProduct.Items?.Count ?? 0));
            if (id != editedProduct.ProductId)
            {
                return NotFound();
            }

            ModelState.Remove("Items.ParentItem");
            ModelState.Remove("Items.Parts.ProductItem");

            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return View(editedProduct);
            }

            var product = await _context.Products
                .Include(p => p.Items)
                    .ThenInclude(item => item.Parts)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            Console.WriteLine("Innan assignment: product.Name = " + product.Name + ", editedProduct.Name = " + editedProduct.Name);

            // Uppdatera produktens egna fält
            product.Name = editedProduct.Name;
            Console.WriteLine("Updated product.Name = " + product.Name);

            product.Description = editedProduct.Description;
            product.Price = editedProduct.Price;
            product.ImageUrl = editedProduct.ImageUrl;
            product.AudioUrl = editedProduct.AudioUrl;
            Console.WriteLine("editedProduct.Name = " + editedProduct.Name);
            if (editedProduct.Items != null && editedProduct.Items.Any())
            {
                Console.WriteLine("editedProduct.Items[0].Name = " + editedProduct.Items.First().Name);
            }
            // Hantera borttagna rum
            var editedItemIds = editedProduct.Items?.Select(i => i.ItemId).ToList() ?? new List<int>();
            var itemsToRemove = product.Items.Where(i => !editedItemIds.Contains(i.ItemId)).ToList();
            foreach (var item in itemsToRemove)
            {
                _context.Remove(item);
            }

            // Uppdatera befintliga rum och deras saker
            foreach (var editedItem in editedProduct.Items ?? new List<ProductItem>())
            {
                var existingItem = product.Items.FirstOrDefault(i => i.ItemId == editedItem.ItemId);
                if (existingItem != null)
                {
                    existingItem.Name = editedItem.Name;
                    existingItem.ImageUrl = editedItem.ImageUrl;
                    existingItem.AudioUrl = editedItem.AudioUrl;

                    // Hantera borttagna saker
                    var editedPartIds = editedItem.Parts?.Select(p => p.PartId).ToList() ?? new List<int>();
                    var partsToRemove = existingItem.Parts.Where(p => !editedPartIds.Contains(p.PartId)).ToList();
                    foreach (var part in partsToRemove)
                    {
                        _context.Remove(part);
                    }

                    // Uppdatera eller lägg till saker
                    foreach (var editedPart in editedItem.Parts ?? new List<ProductPart>())
                    {
                        var existingPart = existingItem.Parts.FirstOrDefault(p => p.PartId == editedPart.PartId);
                        if (existingPart != null)
                        {
                            existingPart.Name = editedPart.Name;
                            existingPart.ImageUrl = editedPart.ImageUrl;
                            existingPart.AudioUrl = editedPart.AudioUrl;
                        }
                        else
                        {
                            // Sätt FK manuellt om nödvändigt:
                            editedPart.ProductItemId = existingItem.ItemId;
                            existingItem.Parts.Add(editedPart);
                        }
                    }
                }
                else
                {
                    // Lägg till nytt rum
                    product.Items.Add(editedItem);
                }
            }

            // Logga ChangeTracker för att se ändringar
            Console.WriteLine(_context.ChangeTracker.DebugView.ShortView);

            try
            {
                _context.Update(product);

                await _context.SaveChangesAsync();
                TempData["Message"] = "Produkten har ändrats.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kunde inte spara ändringarna: " + ex.Message);
                return View(editedProduct);
            }
        }


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

        [Authorize(Roles = "Administrators")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                TempData["Message"] = "Produkten har tagits bort";
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Administrators, Customers")]
        public async Task<IActionResult> Explore(int id)
        {
            var product = await _context.Products
        .Include(p => p.Items)  
        .ThenInclude(item => item.Parts)  
        .FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return Challenge();
            }

            var userId = userIdClaim.Value;
            if (userId == null) { return Challenge(); }

            bool hasPurchases = await _context.Orders
                .Include(o => o.OrderItems)
                .AnyAsync(o => o.UserId == userId && o.OrderItems.Any(oi => oi.ProductId == id));
            
            if (!hasPurchases) 
            {
                TempData["PurchaseMessage"] = "Du måste köpa produkten först för att få åtkomst";
                return RedirectToAction("Details", "Produkt", new { id = id });
            }

            return View(product);
        }
    }
}
