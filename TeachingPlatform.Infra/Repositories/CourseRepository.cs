﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;
using TeachingPlatform.Infra.Context;

namespace TeachingPlatform.Infra.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TeachingContext _context;
        public CourseRepository(TeachingContext context)
        {
            _context = context;
        }

        public async Task<Course> Create(Course course)
        {
            if(course == null)
                throw new ArgumentException(nameof(course));

            _context.Course.Add(course);

            await _context.SaveChangesAsync();

            return course;

        }
    }
}
