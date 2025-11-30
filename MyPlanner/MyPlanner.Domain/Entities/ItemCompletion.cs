using MyPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class ItemCompletion
    {
        public Guid Id { get; set; }

        public Guid UserItemMapperId { get; set; }
        public UserItemMapper UserItemMapper { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
        public int CompletedCount { get; set; }

        public EnumQuality? Quality { get; set; }
        public EnumMood? Mood { get; set; }
        public string Notes { get; set; }
    }
}
