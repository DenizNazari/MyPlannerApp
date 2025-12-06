using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
            builder.Property(c => c.Icon).HasMaxLength(100);
            builder.Property(c => c.IsSystem).HasDefaultValue(false);
            builder.Property(c => c.Order).HasDefaultValue(0);

 
            // User İlişkisi
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Categories)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

             builder.HasOne(c => c.Color)
                   .WithMany()
                   .HasForeignKey(c => c.ColorId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
