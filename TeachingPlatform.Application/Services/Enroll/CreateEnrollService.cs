using System.Net;
using TeachingPlatform.Application;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Interfaces;

public class CreateEnrollService(IEnrollmentRepository enrollmentRepository) : IEnrollCreateService
{
    private readonly IEnrollmentRepository _enrollmentRepository = enrollmentRepository;

    public async Task<Response<EnrollCreateResponse>> Create(EnrollmentInputModel enrollInputModel)
    {
        if (enrollInputModel == null)
            return new Response<EnrollCreateResponse>(null, (int)HttpStatusCode.BadRequest);

        var result = await _enrollmentRepository.Create(enrollInputModel.ToEntity());

        var response =
            new EnrollCreateResponse(
                result?.Course.Name,
                result?.Student.UserName,
                result.CreatedAt);

        return new Response<EnrollCreateResponse>(response);


    }
}