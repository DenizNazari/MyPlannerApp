using MyPlanner.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyPlanner.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        // SQL'de BIGINT denmiş ama şifreler genelde hash'lenmiş string olur.
        // Kod tarafında string tutman en doğrusu.
        public string Password { get; set; }
        public EnumStatus Status { get; set; } // int check default 1
        public string Timezone { get; set; }

        // İlişkiler
        public ICollection<Category> Categories { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
//id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
//name VARCHAR(255) NOT NULL,
//surname VARCHAR(255) NOT NULL,
//email VARCHAR(255) NOT NULL UNIQUE,
//password BIGINT NOT NULL,
//status INT NOT NULL DEFAULT 1,
//timezone VARCHAR(50) NOT NULL DEFAULT 'UTC',
//createdAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
//updatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP