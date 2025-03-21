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

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            bool hasPurchased = false;

            if (userId != null)
            {
                hasPurchased = await _context.Orders
                    .Include(o => o.OrderItems)
                    .AnyAsync(o => o.UserId == userId && o.OrderItems.Any(oi => oi.ProductId == id));
            }

            ViewBag.HasPurchased = hasPurchased;    

            return View(product);
        }

        [Authorize(Roles = "Administrators")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrators")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
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

            product.Name = editedProduct.Name;
            product.Description = editedProduct.Description;
            product.Price = editedProduct.Price;
            product.ImageUrl = editedProduct.ImageUrl;
            product.AudioUrl = editedProduct.AudioUrl;
            var editedItemIds = editedProduct.Items?.Select(i => i.ItemId).ToList() ?? new List<int>();
            var itemsToRemove = product.Items.Where(i => !editedItemIds.Contains(i.ItemId)).ToList();
            foreach (var item in itemsToRemove)
            {
                _context.Remove(item);
            }

            foreach (var editedItem in editedProduct.Items ?? new List<ProductItem>())
            {
                var existingItem = product.Items.FirstOrDefault(i => i.ItemId == editedItem.ItemId);
                if (existingItem != null)
                {
                    existingItem.Name = editedItem.Name;
                    existingItem.ImageUrl = editedItem.ImageUrl;
                    existingItem.AudioUrl = editedItem.AudioUrl;

                    var editedPartIds = editedItem.Parts?.Select(p => p.PartId).ToList() ?? new List<int>();
                    var partsToRemove = existingItem.Parts.Where(p => !editedPartIds.Contains(p.PartId)).ToList();
                    foreach (var part in partsToRemove)
                    {
                        _context.Remove(part);
                    }

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
                            editedPart.ProductItemId = existingItem.ItemId;
                            existingItem.Parts.Add(editedPart);
                        }
                    }
                }
                else
                {
                    product.Items.Add(editedItem);
                }
            }

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

 

        [Authorize(Roles = "Administrators, Customers, Customer")]
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


        [Authorize(Roles = "Administrators, Customers, Customer")]
        public async Task<IActionResult> ExploreRoom(int roomId)
        {
            var room = await _context.ProductItems
                .Include(r => r.Parts)
                .FirstOrDefaultAsync(r => r.ItemId == roomId);
            if (room == null)
            {
                Console.WriteLine("Room not found for roomId: " + roomId);
                return NotFound();
            }
            Console.WriteLine("Room found: " + room.Name);
            Console.WriteLine("Room has " + room.Parts.Count + " parts");
            Console.WriteLine("Received roomId: " + roomId);

            return View(room);
        }
    }
}
