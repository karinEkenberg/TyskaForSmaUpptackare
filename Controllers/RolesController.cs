using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using static System.Console;

namespace TyskaForSmaUpptackare.Controllers
{
    public class RolesController : Controller
    {
        // Hårdkodade roller och e-postadresser
        private readonly string AdminRole = "Administrators";
        private readonly string UserEmail = "k.ekenberg.dev@gmail.com";
        private const string CustomerRole = "Customer";
        private const string CustomerEmail = "karin@exempel.se";

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (!(await roleManager.RoleExistsAsync(AdminRole)))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }

            IdentityUser user = await userManager.FindByEmailAsync(UserEmail);

            if (user == null)
            {
                user = new IdentityUser();
                user.UserName = UserEmail;
                user.Email = UserEmail;

                IdentityResult result = await userManager.CreateAsync(user, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    WriteLine($"Användare {user.UserName} skapades framgångsrikt.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }

            if (!user.EmailConfirmed)
            {
                string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    WriteLine($"Användaren {user.UserName} e-post har bekräftats.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }

            if (!(await userManager.IsInRoleAsync(user, AdminRole)))
            {
                IdentityResult result = await userManager.AddToRoleAsync(user, AdminRole);
                if (result.Succeeded)
                {
                    WriteLine($"Användare {user.UserName} tillagd i {AdminRole} framgångsrikt.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        WriteLine(error.Description);
                    }
                }
            }

            return Redirect("/");
        }

        public async Task<IActionResult> AddCustomer()
        {
            if (!await roleManager.RoleExistsAsync(CustomerRole))
            {
                await roleManager.CreateAsync(new IdentityRole(CustomerRole));
            }

            var customer = await userManager.FindByEmailAsync(CustomerEmail);
            if (customer == null)
            {
                customer = new IdentityUser
                {
                    UserName = CustomerEmail,
                    Email = CustomerEmail
                };

                var createResult = await userManager.CreateAsync(customer, "P@$$w0rd");
                if (!createResult.Succeeded)
                {
                    foreach (var error in createResult.Errors)
                    {
                        WriteLine(error.Description);
                    }
                    return Content("Kunde inte skapa kunden.");
                }
            }

            if (!await userManager.IsInRoleAsync(customer, CustomerRole))
            {
                var roleResult = await userManager.AddToRoleAsync(customer, CustomerRole);
                if (!roleResult.Succeeded)
                {
                    foreach (var error in roleResult.Errors)
                    {
                        WriteLine(error.Description);
                    }
                    return Content("Kunde inte lägga till kunden i rollen 'Customer'.");
                }
            }

            return Content($"Kunden {CustomerEmail} har lagts till i rollen '{CustomerRole}'.");
        }
    }
}
