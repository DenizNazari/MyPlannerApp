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
    public class UserItemMapperConfiguration : IEntityTypeConfiguration<UserItemMapper>
    {
        public void Configure(EntityTypeBuilder<UserItemMapper> builder)
        {
            builder.ToTable("UserItemMapper");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");

            // Tarih ve Saat Ayarı
            builder.Property(x => x.ScheduleDate).HasColumnType("date").IsRequired();
            builder.Property(x => x.ScheduleTime).HasColumnType("time");

            builder.Property(x => x.Notes).HasMaxLength(1000);

            builder.Property(x => x.CompletionStatus)
                .HasConversion<string>()
                .HasMaxLength(20)
                .HasDefaultValue(EnumStatus.Active);

            // İlişkiler
            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Item)
                .WithMany()
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
