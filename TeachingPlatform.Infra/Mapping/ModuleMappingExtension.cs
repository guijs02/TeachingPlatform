using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Mapping
{
    internal static class ModuleMappingExtension
    {
        public static Module ToEntity(this ModuleModel model)
        {
            return new Module
            {
                Course = model.Course.ToEntity(),
                CourseId = model.Course.Id,
                Lessons = model.Lessons.ToEntity(),
            };
        }

        public static ModuleModel ToModel(this Module model)
        {
            return new ModuleModel
            {
                Course = model.Course.ToModel(),
                CourseId = model.Course.Id,
                Lessons = model.Lessons.ToModel(),
            };
        }
    }
}
