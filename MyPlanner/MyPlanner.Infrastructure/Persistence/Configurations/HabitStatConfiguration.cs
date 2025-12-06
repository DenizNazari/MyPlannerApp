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
    public class HabitStatConfiguration : IEntityTypeConfiguration<HabitStat>
    {
        public void Configure(EntityTypeBuilder<HabitStat> builder)
        {
            builder.ToTable("HabitStats");
            builder.HasKey(h => h.Id);

            builder.Property(h => h.AverageQuality).HasColumnType("decimal(18,2)");

            builder.HasOne(h => h.Item)
                .WithMany()
                .HasForeignKey(h => h.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
