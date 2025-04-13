using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ICreateCourseService
    {
        public Task<Response<CourseCreateResponse>> CreateAsync(CourseInputModel courseViewModel, Guid userId);
    }
}
