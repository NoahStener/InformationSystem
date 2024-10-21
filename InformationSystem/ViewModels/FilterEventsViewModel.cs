using InformationSystem.Models;

namespace InformationSystem.ViewModels
{
    public class FilterEventsViewModel
    {
        public int DriverID { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
