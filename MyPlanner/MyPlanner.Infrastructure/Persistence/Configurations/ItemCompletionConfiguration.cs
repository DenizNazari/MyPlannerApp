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
    public class ItemCompletionConfiguration : IEntityTypeConfiguration<ItemCompletion>
    {
        public void Configure(EntityTypeBuilder<ItemCompletion> builder)
        {
            builder.ToTable("ItemCompletions");
            builder.HasKey(ic => ic.Id);

            builder.Property(ic => ic.Notes).HasMaxLength(500);
            builder.Property(ic => ic.Quality).HasConversion<string>().HasMaxLength(20);
            builder.Property(ic => ic.Mood).HasConversion<string>().HasMaxLength(20);

            builder.HasOne(ic => ic.UserItemMapper)
                .WithMany()
                .HasForeignKey(ic => ic.UserItemMapperId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
