using Microsoft.AspNetCore.Mvc;
using Stripe;
using TyskaForSmaUpptackare.Models;
using Stripe.Checkout;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TyskaForSmaUpptackare.Data;
using Microsoft.EntityFrameworkCore;
using TyskaForSmaUpptackare.ViewModel;

namespace TyskaForSmaUpptackare.Controllers
{
    public class PaymentController : Controller
    {
        private readonly StripeSettings _stripeSettings;
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context, IOptions<StripeSettings> stripeOptions)
        {
            _stripeSettings = stripeOptions.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
            _context = context;
        }

        [HttpPost("skapa-checkout-session")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCheckoutSession(int productId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Content("~/Cart") });
            }

            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);  

            if (cart == null || cart.CartItems == null || !cart.CartItems.Any())
            {
                TempData["Message"] = "Din kundvagn är tom..";
                return RedirectToAction("Index", "Kundvagn");
            }

            var purchasedProductIds = await _context.Orders
                .Where(o => o.UserId == userId)
                .SelectMany(o => o.OrderItems.Select(oi => oi.ProductId))
                .ToListAsync();

            var validCartItems = cart.CartItems
                .Where(ci => !purchasedProductIds.Contains(ci.ProductId))
                .ToList();

            if (!validCartItems.Any())
            {
                TempData["Message"] = "Du har redan köpt alla produkter i din kundvagn.";
                return RedirectToAction("Index", "Kundvagn");
            }

            var lineItems = cart.CartItems.Select(ci => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(ci.Product.Price * 100), 
                    Currency = "sek",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ci.Product.Name,
                        Description = ci.Product.Description,
                    },
                },
                Quantity = 1, 
            }).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = Url.Action("Success", "Payment", new { orderId = 0 }, Request.Scheme),
                CancelUrl = Url.Action("Cancel", "Payment", null, Request.Scheme),
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return Redirect(session.Url);
        }

        [HttpGet("lyckad")]
        public async Task<IActionResult> Success()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any()) 
            {
                return RedirectToAction("Index", "Hem");
            }

            var totalPrice = cart.CartItems.Sum(ci => ci.Quantity * ci.Product.Price);

            var order = new Order
            {
                UserId = userId,
                TotalPrice = totalPrice,
				PaymentStatus = "Betald",
                PaymentId = userId,

            };

			foreach (var cartItem in cart.CartItems)
			{
				order.OrderItems.Add(new OrderItem
				{
					ProductId = cartItem.ProductId,
					Quantity = cartItem.Quantity,
					Price = cartItem.Product.Price
				});
			}

            _context.Orders.Add(order);
            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();

			return RedirectToAction("OrderConfirmation", new { orderId = order.OrderId });


		}

		[HttpGet("avbruten")]
        public IActionResult Cancel()
        {
            return View();
        }

        public async Task<IActionResult> OrderConfirmation(int orderId)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderConfirmationViewModel
            {
                OrderId = order.OrderId,
                TotalPrice = order.TotalPrice,
				Items = order.OrderItems.Select(oi => new OrderItemViewModel
				{
					ProductName = oi.Product.Name,
					Price = oi.Price
				}).ToList()
			};

            return View(viewModel);
        }
    }
}