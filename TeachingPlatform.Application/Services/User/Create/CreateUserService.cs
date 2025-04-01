using System.Net;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Application.Services.User.Create
{
    public class CreateUserService(IUserRepository userRepository) : IUserCreateService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<Response<UserCreateResponse>> Create(UserCreateInputModel userCreateViewModel)
        {
            if (userCreateViewModel == null)
                return new Response<UserCreateResponse>(null, (int)HttpStatusCode.BadRequest);

            var entity = userCreateViewModel.ToEntity();

            if (entity.notification.HasErrors())
                return new Response<UserCreateResponse>(null, (int)HttpStatusCode.BadRequest, entity.notification.GetMessages(nameof(User)));

            var result = await _userRepository.Create(entity);

            var response =
                new UserCreateResponse(
                    userCreateViewModel.UserName, userCreateViewModel.TypeOfUser);

            return result
                ? new Response<UserCreateResponse>(response)
                : new Response<UserCreateResponse>(
                    null, (int)HttpStatusCode.InternalServerError, "Opa, ocorreu um erro inesperado!");

        }
    }
}