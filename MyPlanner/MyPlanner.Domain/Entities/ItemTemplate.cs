using MyPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class ItemTemplate
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public enumItemType itemType { get; set; }
        public Guid categoryId { get; set; }
        public Category category  { get; set; }
        public string logo { get; set; }
        public int defaultDailyCount { get; set; }
        public bool isLoop { get; set; }
        public bool canAddToCalendar { get; set; }
        public bool isPremium { get; set; }
        public DateTime estimatedDuration { get; set; }


    }
}
//id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
//name VARCHAR(255) NOT NULL,
//description TEXT,
//itemType VARCHAR(20) NOT NULL CHECK (itemType IN ('HABIT', 'TASK', 'PROJECT')),
//categoryId UUID REFERENCES Categories(id) ON DELETE SET NULL,
//logo VARCHAR(255),
//defaultDailyCount BIGINT DEFAULT 1,
//isLoop BOOLEAN NOT NULL DEFAULT FALSE,
//canAddToCalendar BOOLEAN NOT NULL DEFAULT TRUE,
//isPremium BOOLEAN NOT NULL DEFAULT FALSE,
//estimatedDuration INT