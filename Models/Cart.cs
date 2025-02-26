using System.ComponentModel.DataAnnotations;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
