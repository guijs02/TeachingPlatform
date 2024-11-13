using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlatform.Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;

    }
}
