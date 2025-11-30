using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class HabitStat 
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public int CurrentStreak { get; set; }
        public int LongestStreak { get; set; }
        public int TotalCompletions { get; set; }
        public DateTime? LastCompletedDate { get; set; } // Sadece tarih önemli

        public decimal? AverageQuality { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
