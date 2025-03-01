using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class CourseMappingExtensions
    {
        public static Course ToEntity(this CourseModel model)
        {
            return new Course
            {
                Description = model.Description,
                Name = model.Name,
                Mudules = model.Mudules.ToEntity(),
                TeacherId = model.TeacherId,
                Enrollments = [],
            };
        }

        public static CourseModel ToModel(this Course model)
        {
            return new CourseModel
            {
                Name = model?.Name,
                Enrollments = [],
                Description = model.Description,
                Mudules = model.Mudules.ToModel(),
                TeacherId = model.TeacherId,
            };
        }
    }
}
