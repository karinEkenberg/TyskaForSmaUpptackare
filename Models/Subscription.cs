﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TyskaForSmaUpptackare.Data;

namespace TyskaForSmaUpptackare.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }
        [Required]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Active";
    }
}
