using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Models
{
    public class ProductItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public ICollection<ProductPart> Parts { get; set; } = new List<ProductPart>();
        public string ImageUrl { get; set; } = string.Empty;
        public string AudioUrl { get; set; } = string.Empty;
        public int? ParentItemId { get; set; }
        public ProductItem ParentItem { get; set; }
        public ICollection<ProductItem> ChildItems { get; set; } = new List<ProductItem>();
    }
}
