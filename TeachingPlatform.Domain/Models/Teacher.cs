using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlatform.Domain.Models
{
    public class Teacher 
    {
        public Guid Id { get; set; }
        public List<Course> Courses { get; set; } = null!;
    }
}
