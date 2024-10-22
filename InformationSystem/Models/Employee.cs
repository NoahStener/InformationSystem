using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformationSystem.Models
{
    public class Employee : IdentityUser
    {
        //IdentityUser already has Id property
        //IdentityUser already has Email property
        //IdentityUser uses PasswordHash for 
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public string Role { get; set; }
    }
}
