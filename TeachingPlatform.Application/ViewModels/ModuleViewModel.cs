using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachingPlatform.Application.ViewModels
{
    public class ModuleViewModel
    {
        public string Name { get; set; } = null!;
        public List<LessonViewModel> Lessons { get; set; } = new();
    }
}
