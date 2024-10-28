using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlatform.Domain.Models
{
    public class Teacher : User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Course> Courses { get; set; } = null!;
    }
}
