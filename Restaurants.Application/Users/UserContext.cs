using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }

    public class UserContext(IHttpContextAccessor httpcontextacessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = httpcontextacessor.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context is not presente");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.FindAll(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

            return new CurrentUser(userId, email, roles);
        }
    }
}
