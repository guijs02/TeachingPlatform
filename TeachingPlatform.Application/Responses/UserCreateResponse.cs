using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.Responses
{
    public record UserCreateResponse(string? name = null, bool isSucceeded = false, EUserRole? role = null)
    {
    }
}
