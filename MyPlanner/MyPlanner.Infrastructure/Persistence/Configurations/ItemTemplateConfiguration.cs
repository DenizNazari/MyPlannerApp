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
    public class ItemTemplateConfiguration : IEntityTypeConfiguration<ItemTemplate>
    {
        public void Configure(EntityTypeBuilder<ItemTemplate> builder)
        {
            builder.ToTable("ItemTemplates");
            builder.HasKey(t => t.id); // Sizin kodunuzda küçük harf 'id' idi

            builder.Property(t => t.name).IsRequired().HasMaxLength(255);
            builder.Property(t => t.logo).HasMaxLength(255);

            builder.Property(t => t.itemType)
                .HasConversion<string>()
                .HasMaxLength(20);

            // Category İlişkisi
            builder.HasOne(t => t.category)
                .WithMany(c => c.Templates)
                .HasForeignKey(t => t.categoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
