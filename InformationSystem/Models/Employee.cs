using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InformationSystem.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IdentityUser IdentityUser { get; set; } //inte säker på om denna prop är nödvändig
    }
}
