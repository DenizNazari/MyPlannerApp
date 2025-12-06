using MyPlanner.Domain.Enums;
using System;

namespace MyPlanner.Domain.Entities
{
    public class UserItemMapper
    {
        public Guid Id { get; set; }

        // --- Foreign Keys ---
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        // --- Zamanlama Bilgileri ---

        // Sadece tarih (Örn: 2023-10-25)
        public DateTime ScheduleDate { get; set; }

        // Sadece saat (Örn: 14:30)
        public TimeSpan? ScheduleTime { get; set; }

        public int? Duration { get; set; } // Dakika cinsinden süre

        // --- Gerçekleşen Durum ---
        public DateTime? ActualStartTime { get; set; }
        public DateTime? ActualEndTime { get; set; }

        // --- Durum ve Sonuçlar ---
        public EnumStatus CompletionStatus { get; set; } // ACTIVE, COMPLETED vs.

        public int CompletionPercentage { get; set; } // 0 - 100 arası

        public string Notes { get; set; }

        public DateTime? ReminderTime { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    }
}