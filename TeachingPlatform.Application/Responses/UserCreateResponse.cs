using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.Responses
{
    public record UserCreateResponse(string? name = null, EUserRole? role = null)
    {
    }
}
