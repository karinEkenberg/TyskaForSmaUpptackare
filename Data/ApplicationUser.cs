using Microsoft.AspNetCore.Identity;
using TyskaForSmaUpptackare.Models;

namespace TyskaForSmaUpptackare.Data
{
    public class ApplicationUser : IdentityUser
    {
        public bool isBlocked { get; set; } = false;
        public DateTime? BlockedAt { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public virtual Cart Cart { get; set; }
    }
}
