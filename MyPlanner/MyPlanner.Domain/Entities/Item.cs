using MyPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // --- İlişkiler (Foreign Keys) ---

        public Guid UserId { get; set; }
        public User User { get; set; }

        // SQL'de NULL olabilir dediği için "Guid?" yapıyoruz
        public Guid? TemplateId { get; set; }
        public ItemTemplate Template { get; set; }

        // SQL'de NULL olabilir (Root item'ların parent'ı olmaz)
        public Guid? ParentId { get; set; }
        public Item Parent { get; set; }
        // Bir item'ın alt görevleri olabilir (Self-referencing relationship)
        public ICollection<Item> Children { get; set; }

        // SQL'de CategoryId var, eğer Category entity'si varsa bunu açabilirsin:
        // public Guid? CategoryId { get; set; }
        // public Category Category { get; set; }


        // --- Özellikler ve Enumlar ---

        public enumItemType ItemType { get; set; } // HABIT, TASK, PROJECT

        public EnumPriority Priority { get; set; } // LOW, MEDIUM, HIGH...

        public EnumStatus Status { get; set; } // ACTIVE, COMPLETED...

        // --- Loop / Tekrar Ayarları ---

        public bool IsLoop { get; set; }
        public EnumLoopFrequency? LoopFrequency { get; set; } // DAILY, WEEKLY...

        // --- Diğer ---

        public int? TargetCount { get; set; }       // Hedef sayısı (opsiyonel)
        public int? EstimatedDuration { get; set; } // Tahmini süre (opsiyonel)
        public int Order { get; set; }              // Sıralama


    }
}
//id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
// userId UUID NOT NULL REFERENCES Users(id) ON DELETE CASCADE,
// templateId UUID NULL REFERENCES ItemTemplate(id) ON DELETE SET NULL,
// parentId UUID NULL REFERENCES Items(id) ON DELETE CASCADE,
// itemType VARCHAR(20) NOT NULL CHECK (itemType IN ('HABIT', 'TASK', 'PROJECT')),
// title VARCHAR(500) NOT NULL,
// description TEXT,
// categoryId UUID REFERENCES Categories(id) ON DELETE SET NULL,
// priority VARCHAR(20) CHECK (priority IN ('LOW', 'MEDIUM', 'HIGH', 'URGENT')),
// status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE' CHECK (status IN ('ACTIVE', 'COMPLETED', 'PAUSED', 'ARCHIVED')),
// isLoop BOOLEAN NOT NULL DEFAULT FALSE,
// loopFrequency VARCHAR(20) CHECK (loopFrequency IN ('DAILY', 'WEEKLY', 'MONTHLY', 'CUSTOM')),
// targetCount INT,
// estimatedDuration INT,
//    "order" INT NOT NULL DEFAULT 0,
// createdate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
// updatedate TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP