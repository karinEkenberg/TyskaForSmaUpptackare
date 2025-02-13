using Microsoft.AspNetCore.Identity;

namespace TyskaForSmaUpptackare.Data
{
    public class ApplicationUser : IdentityUser
    {
        public bool isBlocked { get; set; }
        public DateTime? BlockedAt { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
