using Microsoft.AspNetCore.Identity;

namespace Restaurants.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateOnly?  DateOfBirth { get; set; }
        public string? Nacionality { get; set; }
    }
}
