using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public string AudioUrl { get; set; }
        public ICollection<ProductPart> Parts { get; set; } = new List<ProductPart>();
    }
}
