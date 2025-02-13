﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        [MaxLength(30)]
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
    }
}
