using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TyskaForSmaUpptackare.Models;

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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Abc> Abcs { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<NumberOneTwo> NumberOneTwos { get; set; }
        public DbSet<NumbersHundred> NumbersHundred { get; set; }
        public DbSet<NumbersTen> NumbersTens { get; set; }
        public DbSet<NumbersTenEleven> NumbersTenElevens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>()
              .HasMany(o => o.OrderItems)
              .WithOne(oi => oi.Order)
              .HasForeignKey(oi => oi.OrderId)
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
                .HasOne(pp => pp.ProductItem)
                .WithMany(pi => pi.Parts)
                .HasForeignKey(pp => pp.ProductItemId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Product>()
              .HasMany(p => p.Items)
              .WithOne() 
              .HasForeignKey("ProductId") 
              .OnDelete(DeleteBehavior.Cascade);


            // 🔹 Self-referencing relation (ProductItem → ChildItems)
            builder.Entity<ProductItem>()
                .HasOne(i => i.ParentItem)
                .WithMany(i => i.ChildItems)
                .HasForeignKey(i => i.ParentItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationUser>()
               .Property(u => u.isBlocked)
               .HasDefaultValue(false);

            builder.Entity<OrderItem>()
               .Property(oi => oi.Price)
               .HasColumnType("decimal(10,2)");


        }
    }
}
