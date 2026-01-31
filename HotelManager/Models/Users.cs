using Microsoft.AspNetCore.Identity;

namespace HotelManager.Models
{
    public class Users :IdentityUser
    {
        public string FullName { get; set; }
    }
}
