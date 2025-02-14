using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Data
{
    public class ProductItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int ProductPartId { get; set; }
        [ForeignKey("ProductPartId")]
        public ProductPart ProductPart { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
        public int? ParentItemId { get; set; }
        public ProductItem ParentItem { get; set; }
        public ICollection<ProductItem> ChildItems { get; set; } = new List<ProductItem>();
    }
}
