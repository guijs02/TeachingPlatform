using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface IGetAllContentCourseService
    {
        Task<Response<IEnumerable<GetAllContentCourseResponse>>> GetAllContentCourseAsync(Guid courseId, Guid userId);
    }
}
