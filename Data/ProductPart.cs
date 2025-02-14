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
        public string Name { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string AudioUrl { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
