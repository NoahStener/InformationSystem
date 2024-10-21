using InformationSystem.Models;

namespace InformationSystem.ViewModels
{
    public class DriverEventViewModel
    {
        public IEnumerable<Driver> Drivers { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
