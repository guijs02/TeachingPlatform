using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Application.ViewModels;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<Course> Create(CourseViewModel courseViewModel, Guid userId)
        {
            
            Course course = courseViewModel.ToModel();
            course.TeacherId = userId;

            return await _courseRepository.Create(course);
        }
    }
}
