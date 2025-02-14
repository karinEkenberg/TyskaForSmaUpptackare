using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TyskaForSmaUpptackare.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductPart> ProductParts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Subscription>()
                .HasOne(s => s.User)
                .WithMany(u => u.Subscriptions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Subscription>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductPart>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Parts)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ProductItem>()
                .HasOne(i => i.ProductPart)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.ProductPartId)
                .OnDelete(DeleteBehavior.Cascade);

                // 🔹 Self-referencing relation (ProductItem → ChildItems)
                builder.Entity<ProductItem>()
                .HasOne(i => i.ParentItem)
                .WithMany(i => i.ChildItems)
                .HasForeignKey(i => i.ParentItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
