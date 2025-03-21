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

        var courseId = await _enrollmentRepository.Create(enrollInputModel.ToEntity());

        var name = await _enrollmentRepository.GetNameByCourseStudentAsync(courseId, enrollInputModel.StudentId);

        var response =
            new EnrollCreateResponse(
                name,
                DateTime.UtcNow);

        return new Response<EnrollCreateResponse>(response, message: $"Matriculado no courso {response.course}");


    }
}