using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlanner.Domain.Entities
{
    public class Color
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
