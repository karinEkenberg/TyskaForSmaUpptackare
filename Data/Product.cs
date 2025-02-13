using System.ComponentModel.DataAnnotations;

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
        public decimal Price { get; set; }
    }
}
