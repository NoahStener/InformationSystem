using InformationSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace InformationSystem.ViewModels
{
    public class AdminHistoryViewModel
    {
        public IEnumerable<Event> Events { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        public Driver Driver { get; set; }
    }
}
