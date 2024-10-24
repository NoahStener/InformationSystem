using System.ComponentModel.DataAnnotations;

namespace InformationSystem.ViewModels
{
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public string Role { get; set; }
    }
}
