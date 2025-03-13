using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Application.Services.Interfaces
{
    public interface ICreateCourseService
    {
        public Task<Response<CourseResponse>>
            Create(CourseInputModel courseViewModel, Guid userId);
    }
}
