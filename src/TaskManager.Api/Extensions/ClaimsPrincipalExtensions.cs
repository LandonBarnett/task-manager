using System.Security.Claims;

namespace TaskManager.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
            public static string GetUserId(this ClaimsPrincipal user)
            {
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? throw new InvalidOperationException("User ID not found in claims");
            }
        
    }
}
