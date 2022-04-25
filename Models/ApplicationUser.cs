using Microsoft.AspNetCore.Identity;

namespace FerpaAnalisisApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Gender { get; set; }
    }
}
