using Microsoft.AspNetCore.Mvc;
using Stripe;
using TyskaForSmaUpptackare.Models;
using Stripe.Checkout;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TyskaForSmaUpptackare.Data;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult CreateCheckoutSession()
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },

                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = 5000,
                            Currency = "sek",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Interaktiv produkt",
                                Description = "Ett interaktivt element för barn",
                            },
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = Url.Action("Success", "Payment", null, Request.Scheme),
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

            return RedirectToAction("OderConfirmation", new { orderId = order.OrderId });

        }

        [HttpGet("avbruten")]
        public IActionResult Cancel()
        {
            return View();
        }
    }
}