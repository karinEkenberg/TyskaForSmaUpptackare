using System.ComponentModel.DataAnnotations;

namespace TyskaForSmaUpptackare.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
