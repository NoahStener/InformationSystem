using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InformationSystem.Models
{
    public class Employee : IdentityUser
    {
        [Key]
        [NotMapped]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
