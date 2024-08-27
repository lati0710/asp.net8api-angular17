using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class Account : IdentityUser
    {
        public int MyProperty { get; set; }
    }
}
