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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryID);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(c => c.Name)
                .IsUnique();

            builder.Property(c => c.Description)
                .HasMaxLength(200);
        }
    }
}
