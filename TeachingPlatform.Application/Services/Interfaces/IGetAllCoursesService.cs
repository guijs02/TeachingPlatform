using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IGetAllCoursesService
    {
        Task<PagedResponse<List<CourseGetAllResponse>>> GetAllCoursesAsync(PagedRequest pagedRequest, Guid userId);
    }
}
