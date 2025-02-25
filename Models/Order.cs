using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
