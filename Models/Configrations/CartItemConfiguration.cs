using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configrations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.CartItemID);

            builder.Property(ci => ci.Quantity)
                .IsRequired();

            builder.Property(ci => ci.DateAdded)
                .HasDefaultValueSql("GETDATE()");

            // Relataionship with User
            builder.HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ci => ci.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship with Product
            builder.HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
