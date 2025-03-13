using System.Text.Json.Serialization;

namespace TeachingPlatform.Application.Responses
{
    public record UserLoginResponse(string token)
    {
    }
}
