using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPlanner.Domain.Entities;
using MyPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Infrastructure.Persistence.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(i => i.Id); // Item classına Id eklediğinizi varsayıyorum

            builder.Property(i => i.Title).IsRequired().HasMaxLength(500);
            builder.Property(i => i.Description).HasColumnType("TEXT");

            // --- Enums ---
            builder.Property(i => i.ItemType).HasConversion<string>().HasMaxLength(20);
            builder.Property(i => i.Priority).HasConversion<string>().HasMaxLength(20);
            builder.Property(i => i.Status).HasConversion<string>().HasMaxLength(20).HasDefaultValue(EnumStatus.Active);
            builder.Property(i => i.LoopFrequency).HasConversion<string>().HasMaxLength(20);

            // --- İlişkiler ---

            builder.HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(i => i.Template)
                .WithMany()
                .HasForeignKey(i => i.TemplateId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(i => i.Parent)
                .WithMany(i => i.Children)
                .HasForeignKey(i => i.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            // SQL'de CategoryId varsa bu ilişkiyi de açıyoruz:
            // builder.HasOne(i => i.Category)
            //     .WithMany(c => c.Items)
            //     .HasForeignKey(i => i.CategoryId)
            //     .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
