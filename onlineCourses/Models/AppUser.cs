using Microsoft.AspNetCore.Identity;

namespace onlineCourses.Models
{
    public class AppUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
