using MyPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public bool IsSystem { get; set; }
        public int Order { get; set; }

        // İlişkiler
        public ICollection<Item> Items { get; set; }
        public ICollection<ItemTemplate> Templates { get; set; }

    }
}
//id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
//userId UUID NULL REFERENCES Users(id) ON DELETE CASCADE,
//name VARCHAR(255) NOT NULL,
//color VARCHAR(50) DEFAULT '#3B82F6',
//icon VARCHAR(100),
//isSystem BOOLEAN NOT NULL DEFAULT FALSE,
//    "order" INT NOT NULL DEFAULT 0