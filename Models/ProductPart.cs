using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Models
{
    public class ProductPart
    {
        [Key]
        public int PartId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public int ProductItemId { get; set; }
        [ForeignKey("ProductItemId")]
        [BindNever]
        public ProductItem? ProductItem { get; set; } = default!;
        public string AudioUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
