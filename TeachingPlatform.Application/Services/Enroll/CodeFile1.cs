using System.Net;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Interfaces;

public class CreateEnrollService(IUserRepository userRepository) : IEnrollCreateService
{
    private readonly IUserRepository _userRepository = userRepository;

    //public async Task<Response<EnrollCreateResponse>> Create(EnrollmentInputModel enrollInputModel)
    //{
    //    if (enrollInputModel == null)
    //        return new Response<EnrollCreateResponse>(null, (int)HttpStatusCode.BadRequest);

    //    var result = await _userRepository.Create(enrollInputModel.ToModel());

    //    var response =
    //        new UserCreateResponse(
    //            userCreateViewModel.UserName, userCreateViewModel.TypeOfUser);

    //    return result
    //        ? new Response<UserCreateResponse>(response)
    //        : new Response<UserCreateResponse>(
    //            null, (int)HttpStatusCode.InternalServerError, "Opa, ocorreu um erro inesperado!");

    //}
}