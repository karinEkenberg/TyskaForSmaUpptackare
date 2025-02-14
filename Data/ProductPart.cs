using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Data
{
    public class ProductPart
    {
        [Key]
        public int PartId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = default!;
        public string AudioUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
