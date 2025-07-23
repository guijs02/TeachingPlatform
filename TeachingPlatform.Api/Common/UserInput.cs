using System.Security.Claims;

namespace TeachingPlatform.Api.Common
{
    internal sealed class UserInput
    {
        internal static Guid GetUserId(ClaimsPrincipal user)
        {
            Guid userId;

            var id = user.FindFirstValue("id");

            if (!Guid.TryParse(id, out userId))
                throw new FormatException();

            return userId;
        }
    }
}
