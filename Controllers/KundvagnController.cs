using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using TyskaForSmaUpptackare.Data;
using TyskaForSmaUpptackare.Models;
using TyskaForSmaUpptackare.ViewModel;
using static TyskaForSmaUpptackare.ViewModel.CartViewModel;

namespace TyskaForSmaUpptackare.Controllers
{
    [Authorize]
    public class KundvagnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KundvagnController (ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CartController
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var userId = userIdClaim.Value;

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var viewModel = new CartViewModel
            {
                CartId = cart.CartId,
                Items = (cart.CartItems ?? new List<CartItem>()).Select(ci => new CartViewModel.CartItemViewModel
                {
                    CartItemId = ci.CartItemId,
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity,
                    ImageUrl = ci.Product.ImageUrl
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, string returnUrl)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Content("~/Cart")});
            }

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();

            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem != null)
            {
                TempData["Message"] = "Produkten finns redan i din kundvagn.";
            }
            else
            {
                cartItem = new CartItem
                {
                    CartId = cart.CartId,
                    ProductId = productId,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
                TempData["Message"] = "Produkten lades till i kundvagnen.";
            }
            await _context.SaveChangesAsync();

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToAction("Index", "Cart");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart(int productId, string returnUrl)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account", new { ReturnUrl = returnUrl ?? Url.Content("~/Cart")});
            }

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                if (cartItem != null)
                {
                    _context.CartItems.Remove(cartItem);
                    await _context.SaveChangesAsync();
                    TempData["Message"] = "Produkten togs bort från kundvagnen.";
                }
            }

            if(!string.IsNullOrEmpty(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            return RedirectToAction("Index", "Cart");
        }
    } 
}
