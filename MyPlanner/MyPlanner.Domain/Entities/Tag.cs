using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public string Name { get; set; }
        public string Color { get; set; }

        public ICollection<ItemTag> ItemTags { get; set; }
    }
}
