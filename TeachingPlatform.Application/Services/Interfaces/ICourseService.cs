using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.ViewModels;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ICourseService
    {
        public Task<CourseViewModel> Create(CourseViewModel courseViewModel);
    }
}
