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
    public class ItemTagConfiguration : IEntityTypeConfiguration<ItemTag>
    {
        public void Configure(EntityTypeBuilder<ItemTag> builder)
        {
            builder.ToTable("ItemTags");
            // Composite Key
            builder.HasKey(it => new { it.ItemId, it.TagId });

            builder.HasOne(it => it.Item)
                .WithMany() // Item.ItemTags kolleksiyonu varsa parantez içine yazın
                .HasForeignKey(it => it.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(it => it.Tag)
                .WithMany(t => t.ItemTags)
                .HasForeignKey(it => it.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
