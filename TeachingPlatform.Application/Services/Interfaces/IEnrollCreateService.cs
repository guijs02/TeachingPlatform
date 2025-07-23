using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.Domain.Interfaces
{
    public interface IEnrollCreateService
    {
        Task<Response<EnrollCreateResponse>> Create(EnrollmentInputModel enrollInputModel);
    }
}
