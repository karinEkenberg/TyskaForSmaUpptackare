using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public int? ProductId { get; set; } // foreign key till Products-tabellen
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int? ParentItemId { get; set; }
        [BindNever]
        public ProductItem? ParentItem { get; set; }
        [BindNever]
        public ICollection<ProductItem> ChildItems { get; set; } = new List<ProductItem>();
    }
}
